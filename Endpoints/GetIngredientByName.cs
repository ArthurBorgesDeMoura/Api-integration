using Flurl.Http;
using IRecepiesApp.Endpoints.DTO;
using Microsoft.AspNetCore.Mvc;

namespace IRecepiesApp.Endpoints;

public class GetIngredientsByName
{
    public static string Template => "/ingredients";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IConfiguration configuration, [FromQuery] string name)
    {
        string _baseUrl = configuration["RapidApi:BaseUrl"];
        string _key = configuration["RapidApi:X-RapidAPI-Key"];
        var response = await $"{_baseUrl}/recipes/auto-complete?prefix={name}"
            .WithHeader("X-RapidAPI-Key", _key)
            .GetJsonAsync<GetIngredientsByNameResponseDTO>();
        return Microsoft.AspNetCore.Http.Results.Ok(response);
    }
}
