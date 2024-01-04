namespace Devblogs;

using Devblogs.Core.Routing;
using Devblogs.Routes;

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

        // GET /posts
        routeManager.RegisterRoute(new PostsRoute());
    }
}
