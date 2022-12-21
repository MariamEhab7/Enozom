using DAL.Models;
using Newtonsoft.Json;

namespace BAL.DTOs;

public class GetCountriesDTO
{
    public bool error { get; set; }
    public string msg { get; set; }

    public IList<CountryDTO> data { get; set; } 

    
}
