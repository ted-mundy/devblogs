using Devblogs.Models.Post;
using Microsoft.AspNetCore.Authentication;

class PostSerializer : Serializer {
    private int PostId { get; set; }
    private string Title { get; set; }
    private string Content { get; set; }
    private string OriginalUrl { get; set; }
    private DateTime CreatedAt { get; set; }
    private DateTime UpdatedAt { get; set; }
    public PostSerializer(Post post) {
        PostId = post.PostId;
        Title = post.Title;
        Content = post.Content;
        OriginalUrl = post.OriginalUrl;
        CreatedAt = post.CreatedAt;
        UpdatedAt = post.UpdatedAt;
    }

    public override Dictionary<string, object> Serialize() {
        return new Dictionary<string, object>() {
            { "postId", PostId },
            { "title", Title },
            { "content", Content },
            { "originalUrl", OriginalUrl },
            { "createdAt", CreatedAt },
            { "updatedAt", UpdatedAt }
        };
    }

    public static PaginatedObject<Dictionary<string, object>> SerializePaginatedObject(PaginatedObject<Post> obj) {
        List<Dictionary<string, object>> serializedPosts = new();
        foreach (Post post in obj.Items) {
            serializedPosts.Add(new PostSerializer(post).Serialize());
        }

        return new PaginatedObject<Dictionary<string, object>>(serializedPosts, obj.TotalItems, obj.Page, obj.PageSize, obj.TotalPages);
    }
}