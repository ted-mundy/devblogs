namespace Devblogs.Routes.Health;

using Devblogs.Core.Routing;
using System.Text.Json;

public class HealthRoute : IRoute {
  public RouteData RouteData { get; } = new RouteData {
    Path = "",
    Method = HttpMethod.Get,
    RateLimited = false
  };

  public Func<HttpRequest, HttpResponse, Task> Handler { get; } = async (req, res) => {
    var requestStats = GetRequestStats(req);

    res.Headers.TryAdd("Content-Type", "application/json");

    await res.WriteAsync(JsonSerializer.Serialize(requestStats, new JsonSerializerOptions {
      WriteIndented = true
    }));
  };

  private static Dictionary<string, string> GetRequestStats(HttpRequest request) {
    Dictionary<string, string> requestStats = new()
    {
        { "Method", request.Method },
        { "Path", request.Path },
        { "Timestamp", DateTime.Now.ToString() },
        { "User-Agent", request.Headers["User-Agent"].ToString() },
        { "Protocol", request.Protocol },
        { "Message", "Can you hear me?" }
    };

    return requestStats;
  }
}
