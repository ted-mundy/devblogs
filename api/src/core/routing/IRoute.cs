namespace Devblogs.Core.Routing;

public interface IRoute {
  public RouteData RouteData { get; }
  public Func<HttpRequest, HttpResponse, Task> Handler { get; }
}
