using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Devblogs.Models.Post;

public class Post {
  public int PostId { get; set; }
  public string Title { get; set; }
  public string Content { get; set; }
  public string OriginalUrl { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public Post(string title, string content, string originalUrl) {
    Title = title;
    Content = content;
    OriginalUrl = originalUrl;

    CreatedAt = DateTime.Now;
    UpdatedAt = DateTime.Now;
  }
}
