namespace Devblogs.Core.Routing;

public class RouteManager {
  private static RouteManager? instance;
  private readonly WebApplication application;

  public RouteManager(ref WebApplication _application) {
    if (instance == null) {
      instance = this;
    } else {
      throw new Exception("RouteManager already exists!");
    }

    application = _application;
  }

  public static RouteManager GetInstance() {
    if (instance == null) {
      throw new Exception("RouteManager does not exist!");
    }

    return instance;
  }

  public void RegisterRoute(RouteData routeData, Func<HttpRequest, HttpResponse, Task> handler) {
    RouteHandlerBuilder? builder = null;
    switch (routeData.Method) {
      case HttpMethod.Get:
        builder = application.MapGet(routeData.Path, handler);
        break;
      case HttpMethod.Put:
        builder = application.MapPut(routeData.Path, handler);
        break;
      case HttpMethod.Delete:
        builder = application.MapDelete(routeData.Path, handler);
        break;
      case HttpMethod.Post:
        builder = application.MapPost(routeData.Path, handler);
        break;
      default:
        throw new Exception("Invalid HTTP method! How have you even managed to do this?");
    }

    if (routeData.RateLimited) {
      const string rateLimitingPolicyName = "default";

      builder.RequireRateLimiting(rateLimitingPolicyName);
    }
  }

  public void RegisterRoute(IRoute routeClass) {
    RegisterRoute(routeClass.RouteData, routeClass.Handler);
  }
}
