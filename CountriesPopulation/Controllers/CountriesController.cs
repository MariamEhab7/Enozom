using CountriesPopulation.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CountriesPopulation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : ControllerBase
{
    private readonly ICountry _country;

    public CountriesController(ICountry country)
    {
        _country = country;    
    }

    [HttpGet ("GetCountries")]
    public async Task<IActionResult> GetCountries()
    {
        var result = await _country.AllCountries();
        return Ok(result);
    }

    [HttpPost ("AddCountries")]
    public async Task<IActionResult> AddCountry()
    {
        var result = await _country.AddCountries();
        return Ok(result);
    }

    [HttpPut ("UpdateCountry")]
    public async Task<IActionResult> UpdateCountry()
    {
        var result = await _country.UpdateCountry();
        return Ok(result);
    }

    [HttpGet ("GetAllCountries")]
    public async Task<IActionResult> ListCountries()
    {
        var result = await _country.GetAllCountries();
        return Ok(result);
    }

    [HttpGet ("GetCountryPopulation")]
    public async Task<IActionResult> CountriesPopulation(string code)
    {
        var result = await _country.GetCountriesWithPopulation(code);
        return Ok(result);
    }

}