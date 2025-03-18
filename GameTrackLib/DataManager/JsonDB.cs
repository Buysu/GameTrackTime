using System.Text.Json;

namespace GameTrackLib.DataManager;

public class JsonDB<T>
{
    private string filePath;
    
    public JsonDB(string path)
    {
        filePath = path;
        if (!File.Exists(filePath))
            File.Create(filePath);
    }

    public List<T> Load()
    {
        using var reader = new StreamReader(filePath) ;
        var json = reader.ReadToEnd();
        return JsonSerializer.Deserialize<List<T>>(json) ?? [];

    }

    public void Save(List<T> list)
    {
        using var writer = new StreamWriter(filePath);
        var json = JsonSerializer.Serialize(list);
        writer.Write(json);
    }
}