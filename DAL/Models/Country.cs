
using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Country
{
    public Country()
    {
        this.PopulationCounts = new HashSet<PopulationCount>();
    }
    public string? Name { get; set; }
    [Key]
    public string? Code { get; set; }
    public string? Iso3 { get; set; }


    public ICollection<PopulationCount> PopulationCounts { get; set; }


}
