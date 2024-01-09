namespace Devblogs;

using Devblogs.Core.Routing;
using Devblogs.Routes.Posts;
using Devblogs.Routes.Health;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRateLimiter(_ => _
            .AddFixedWindowLimiter("default", options => {
                options.PermitLimit = 10;
                options.Window = TimeSpan.FromSeconds(1);
            }).RejectionStatusCode = 429
        );

        var app = builder.Build();

        app.UseRateLimiter();

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
        return
        [
            // GET /posts
            new PostsRoute(),
            new HealthRoute()
        ];
    }
}
