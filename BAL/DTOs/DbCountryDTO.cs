
using DAL.Models;

namespace BAL.DTOs;

public class DbCountryDTO
{
    public DbCountryDTO()
    {
        this.PopulationCounts = new HashSet<PopulationDTO>();
    }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Iso3 { get; set; }


    public ICollection<PopulationDTO> PopulationCounts { get; set; }

}
