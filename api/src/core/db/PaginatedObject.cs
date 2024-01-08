public class PaginatedObject<T> {
  public List<T> Items { get; set; }
  public int TotalItems { get; set; }
  public int Page { get; set; }
  public int PageSize { get; set; }
  public int TotalPages { get; set; }

  public PaginatedObject(List<T> items, int totalItems, int page, int pageSize, int totalPages) {
    Items = items;
    TotalItems = totalItems;
    Page = page;
    PageSize = pageSize;
    TotalPages = totalPages;
  }

  public static PaginatedObject<T>? PaginateQueryable(IQueryable<T> queryable, int page = 1, int pageSize = 10) {
    int totalItems = queryable.Count();
    int totalPages = (int) Math.Ceiling((double) totalItems / pageSize);

    page = Math.Max(page, 1);

    List<T> items = queryable
      .Skip((page - 1) * pageSize)
      .Take(pageSize)
      .ToList();

    int actualPage = Math.Min(page, totalPages);

    PaginatedObject<T> paginatedItems = new(items, totalItems, actualPage, pageSize, totalPages);

    return paginatedItems;
  }
}