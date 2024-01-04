namespace Devblogs.Routes.Posts;

using Devblogs.Core.Routing;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class PostsRoute : IRoute {
  public RouteData RouteData { get; } = new RouteData {
    Path = "/posts",
    Method = HttpMethod.Get
  };

  public Func<HttpRequest, HttpResponse, Task> Handler { get; } = async (req, res) => {
    using var db = new BlogContext();

    if (db.Posts == null) {
      await res.WriteAsync("No posts found!");
      return;
    }

    // todo: implement pagination
    var posts = await db.Posts.ToListAsync();

    await res.WriteAsync(JsonSerializer.Serialize(posts, new JsonSerializerOptions {
      WriteIndented = true
    }));
  };
}
