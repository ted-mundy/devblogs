using System.Text.Json;

abstract class Serializer : ISerializer {
    public static string SerializeDictionary(Dictionary<string, object> obj) {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions {
          WriteIndented = true
        });
    }

    public static string SerializePaginatedResponse(PaginatedObject<Dictionary<string, object>> obj) {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions {
          WriteIndented = true
        });
    }

    public abstract Dictionary<string, object> Serialize();
}
