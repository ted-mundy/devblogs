namespace routes;

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
    switch (routeData.Method) {
      case HttpMethod.Get:
        application.MapGet(routeData.Path, handler);
        break;
      case HttpMethod.Put:
        application.MapPut(routeData.Path, handler);
        break;
      case HttpMethod.Delete:
        application.MapDelete(routeData.Path, handler);
        break;
      case HttpMethod.Post:
        application.MapPost(routeData.Path, handler);
        break;
      default:
        throw new Exception("Invalid HTTP method! How have you even managed to do this?");
    }
  }
}
