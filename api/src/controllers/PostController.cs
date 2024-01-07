namespace Devblogs.Controllers.Post;

using Devblogs.Core.Db;
using Devblogs.Models.Post;

class PostController {
  public static PaginatedObject<Post>? FilterPosts(string filter, int page = 1, int pageSize = 10) {
    // * Posts are filtered on multiple fields:
    // * - Title
    // * - Content
    // * - OriginalUrl
    // * - Any tags associated with the post (not implemented yet)

    // The filter is taken as a single string, and we'll split it into
    // individual words to search for. These words will be ANDed together,
    // rather than ORed, so that we can narrow down the results.

    BlogContext context = new();
    if (context.Posts == null) {
      return null;
    }

    string[] splitFilter = filter.Split(' ');

    IQueryable<Post> query = context.Posts;

    foreach (string word in splitFilter) {
      query = query.Where(post => post.Title.Contains(word) || post.Content.Contains(word) || post.OriginalUrl.Contains(word));
    }

    return PaginatedObject<Post>.PaginateQueryable(query, page, pageSize);
  }
}