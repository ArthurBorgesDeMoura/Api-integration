namespace IRecepiesApp.Endpoints.DTO;

public class GetIngredientsByNameResponseDTO
{
    public List<Results> Results { get; set; }

}

public partial class Results
{
    public string Search_value { get; set; }
    public string Type { get; set; }
    public string Display { get; set; }
}
