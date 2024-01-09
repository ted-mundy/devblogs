namespace Devblogs.Core.Db;

using Microsoft.EntityFrameworkCore;
using Devblogs.Models.BlogSource;
using Devblogs.Models.Post;

public class BlogContext : DbContext {
  public DbSet<BlogSource>? BlogSources { get; set; }
  public DbSet<Post>? Posts { get; set; }

  private string DbPath { get; set; }

  public BlogContext() {
    // todo: check if in development mode, if so, use sqlite.
    var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    var path = Path.Combine(folder, "devblogs.db");
    DbPath = path;
  }

  // todo: sort this method out, and prepare for production/different environments.
  protected override void OnConfiguring(DbContextOptionsBuilder options) {
    var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;

    if (isDevelopment) {
      options.UseSqlite($"Data Source={DbPath}");
      return;
    }

    string? connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

    if (connectionString == null) throw new Exception("No DB_CONNECTION_STRING environment variable found!");

    // we use postgres :p
    options.UseNpgsql(connectionString);
  }
}