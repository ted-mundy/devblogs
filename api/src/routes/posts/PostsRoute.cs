namespace Devblogs.Routes.Posts;

using Devblogs.Core.Routing;

public class PostsRoute : IRoute {
  public RouteData RouteData { get; } = new RouteData {
    Path = "/posts",
    Method = HttpMethod.Get
  };

  public Func<HttpRequest, HttpResponse, Task> Handler { get; } = async (req, res) => {
    await res.WriteAsync(req.Headers["User-Agent"].ToString());
  };
}
