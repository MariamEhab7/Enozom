using BAL.DTOs;
using Newtonsoft.Json;

namespace BAL.Services;

public class HttpService
{ 
    private readonly HttpClient _httpClient = new HttpClient();
    public async Task<GetCountriesDTO> GetHttpRequest()
    {

        try
        {
            var endpoint = new Uri("https://countriesnow.space/api/v0.1/countries/population");
            var result = _httpClient.GetAsync(endpoint).Result;
            string? jsonString = result.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<GetCountriesDTO>(jsonString);

            return responseObject;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }

    }
}
