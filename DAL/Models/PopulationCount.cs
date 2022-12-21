using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class PopulationCount
{
    public int Id { get; set; }
    public int Year { get; set; }
    public ulong Value { get; set; }
   
    public Country? Country { get; set; }

}
