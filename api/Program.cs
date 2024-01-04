namespace Devblogs;

using Devblogs.Core.Routing;
using Devblogs.Routes.Posts;
using Devblogs.Routes.Health;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        RegisterRoutes(ref app);

        app.Run();
    }

    private static void RegisterRoutes(ref WebApplication app) {
        var routeManager = new RouteManager(ref app);

        foreach (var route in GetRoutes()) {
            routeManager.RegisterRoute(route);
        }
    }

    private static List<IRoute> GetRoutes() {
        return new()
        {
            // GET /posts
            new PostsRoute(),
            new HealthRoute()
        };
    }
}
