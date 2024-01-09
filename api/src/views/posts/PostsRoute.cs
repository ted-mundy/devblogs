namespace Devblogs.Routes.Posts;

using Devblogs.Core.Routing;
using Devblogs.Controllers.Post;
using Devblogs.Models.Post;

public class PostsRoute : IRoute {
  public RouteData RouteData { get; } = new RouteData {
    Path = "/posts",
    Method = HttpMethod.Get,
    RateLimited = true
  };

  public Func<HttpRequest, HttpResponse, Task> Handler { get; } = async (req, res) => {
    // req.Query.TryGetValue("filter", out var filterString);
    // req.Query.TryGetValue("page", out var pageString);

    // if (pageString == null) {
    //   pageString = "1";
    // }

    string? filterString = req.Query["filter"];
    string? pageString = req.Query["page"];

    filterString ??= "";
    pageString ??= "1";

    int pageInt = 1;

    try {
      pageInt = int.Parse(pageString);
    } catch (FormatException) {
      // * If the page number is not a number, we'll just default to 1.
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
