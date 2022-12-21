using CountriesPopulation.Interfaces;

namespace CountriesPopulation.Services;

public class country : ICountry
{
    static readonly HttpClient _httpClient = new HttpClient();

    public string AllCountries()
    {
        var endpoint = new Uri("https://countriesnow.space/api/v0.1/countries/capital");
        var result = _httpClient.GetAsync(endpoint).Result;
        var json = result.Content.ReadAsStringAsync().Result;
        return json;
    }

}
