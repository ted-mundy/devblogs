namespace Devblogs.Core.Routing;

/// <summary>
/// Custom enumeration for HTTP methods. I would have used the built-in one, but it's not an enum,
/// and the other one would be a pain to use, as it'd need loads of dumb "using" statements.
/// </summary>
public enum HttpMethod {
  Get,
  Put,
  Delete,
  Post
}
