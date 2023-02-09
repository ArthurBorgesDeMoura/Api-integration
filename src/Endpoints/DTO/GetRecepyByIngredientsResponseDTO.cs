using Newtonsoft.Json;
namespace IRecepiesApp.Endpoints.DTO;

public class GetRecepyByIngredientsResponseDTO
{
    public int Count { get; set; }

    [JsonProperty("Results")]
    public List<RecepyResults> Results { get; set; }

}

public partial class RecepyResults
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Thumbnail_url { get; set; }
    public string Original_video_url { get; set; }
    public List<Instructions> Instructions { get; set; }
    public List<Sections> Sections { get; set; }
}

public partial class Instructions
{
    public string Display_text { get; set; }
}

public partial class Sections
{
    public List<Components> Components { get; set; }
}

public partial class Components
{
    public string Raw_text { get; set; }
}