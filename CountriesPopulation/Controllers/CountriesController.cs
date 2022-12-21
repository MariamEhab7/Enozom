using CountriesPopulation.Interfaces;
using Microsoft.AspNetCore.Http;
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

    [HttpGet]
    public async Task<IActionResult> GetCountries()
    {
        var result = _country.AllCountries();
        return Ok(result);
    }

}