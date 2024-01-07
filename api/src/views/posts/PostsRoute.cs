namespace Devblogs.Routes.Posts;

using Devblogs.Core.Routing;
using System.Text.Json;
using Devblogs.Controllers.Post;
using Devblogs.Models.Post;

public class PostsRoute : IRoute {
  public RouteData RouteData { get; } = new RouteData {
    Path = "/posts",
    Method = HttpMethod.Get
  };

  public Func<HttpRequest, HttpResponse, Task> Handler { get; } = async (req, res) => {
    // using var db = new BlogContext();

    // if (db.Posts == null) {
    //   await res.WriteAsync("No posts found!");
    //   return;
    // }

    // // todo: implement pagination
    // var posts = await db.Posts.ToListAsync();

    // await res.WriteAsync(JsonSerializer.Serialize(posts, new JsonSerializerOptions {
    //   WriteIndented = true
    // }));

    string filterString = req.Query.TryGetValue("filter", out var filter) ? filter : "";
    string pageString = req.Query.TryGetValue("page", out var page) ? page : "1";
    int pageInt = 1;

    try {
      pageInt = int.Parse(pageString);
    } catch (FormatException) {
      await res.WriteAsync("Invalid page number!");
      return;
    }

    PaginatedObject<Post>? posts = PostController.FilterPosts(filterString, pageInt);
    if (posts == null) {
      await res.WriteAsync("No posts found!");
      return;
    }

    var paginatedPosts = PostSerializer.SerializePaginatedObject(posts);

    res.ContentType = "application/json";
    await res.WriteAsync(PostSerializer.SerializePaginatedResponse(paginatedPosts));
  };
}
