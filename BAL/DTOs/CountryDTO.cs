using Newtonsoft.Json;

namespace BAL.DTOs;

public class CountryDTO
{
    public CountryDTO()
    {
        this.PopulationCounts = new HashSet<PopulationDTO>();
    }

  
    [JsonProperty("country")]
    public string Name { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("iso3")]
    public string Iso3 { get; set; }

    [JsonProperty("populationCounts")]
    public ICollection<PopulationDTO> PopulationCounts { get; set; }
}