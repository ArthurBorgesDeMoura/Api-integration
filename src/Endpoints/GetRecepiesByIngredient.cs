using Flurl.Http;
using IRecepiesApp.Endpoints.DTO;
using Microsoft.AspNetCore.Mvc;

namespace IRecepiesApp.Endpoints;

public class GetRecepiesByIngredient
{
    public static string Template => "/recepies";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(IConfiguration configuration, [FromQuery] string name, [FromQuery] int from = 0, [FromQuery] int size = 20)
    {
        string _baseUrl = configuration["RapidApi:BaseUrl"];
        string _key = configuration["RapidApi:X-RapidAPI-Key"];
        if(size > 50)
            return Microsoft.AspNetCore.Http.Results.BadRequest("max value of size is 50");

        var response = await $"{_baseUrl}/recipes/list?from={from}&size={size}&q={name}"
            .WithHeader("X-RapidAPI-Key", _key)
            .GetJsonAsync<GetRecepyByIngredientsResponseDTO>();
        return Microsoft.AspNetCore.Http.Results.Ok(response);
    }
}