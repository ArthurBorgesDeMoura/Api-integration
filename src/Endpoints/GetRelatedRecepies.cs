using Flurl.Http;
using IRecepiesApp.Endpoints.DTO;
using Microsoft.AspNetCore.Mvc;

namespace IRecepiesApp.Endpoints;

public class GetReletatedRecepiesById
{
    public static string Template => "/recepies/related-recepies";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IConfiguration configuration, [FromQuery] int? id)
    {
        string _baseUrl = configuration["RapidApi:BaseUrl"];
        string _key = configuration["RapidApi:X-RapidAPI-Key"];
        if (id == null)
        {
            return Microsoft.AspNetCore.Http.Results.BadRequest("id is required");
        }

        var response = await $"{_baseUrl}/recipes/list-similarities?recipe_id={id}"
            .WithHeader("X-RapidAPI-Key", _key)
            .DownloadFileAsync("[local path file]");
            .GetJsonAsync<GetRecepyByIngredientsResponseDTO>();
        return Microsoft.AspNetCore.Http.Results.Ok(response);
    }
}