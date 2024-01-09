namespace Devblogs.Core.Routing;

public struct RouteData {
  public string Path;
  public HttpMethod Method;
  public bool RateLimited;
}
