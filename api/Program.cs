namespace api;

using routes;

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
        RouteManager routeManager = new routes.RouteManager(ref app);

        routeManager.RegisterRoute(new routes.RouteData {
            Path = "/",
            Method = routes.HttpMethod.Get
        }, async (req, res) => {
            await res.WriteAsync("Hello, world!");
        });
    }
}
