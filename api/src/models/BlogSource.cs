using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Devblogs.Models.BlogSource;

public class BlogSource {
  public int BlogSourceId { get; set; }
  public string Name { get; set; }
  public string Url { get; set; }
  public List<Post.Post>? Posts { get; set; } = null;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public BlogSource(string name, string url) {
    Name = name;
    Url = url;

    CreatedAt = DateTime.Now;
    UpdatedAt = DateTime.Now;
  }
}
