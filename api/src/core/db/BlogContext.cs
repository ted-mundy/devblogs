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
  protected override void OnConfiguring(DbContextOptionsBuilder options)
      => options.UseSqlite($"Data Source={DbPath}");
}