using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context;

public class CountryDBContext : DbContext
{

    public CountryDBContext(DbContextOptions<CountryDBContext> options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<PopulationCount> PopulationCounts { get; set; }

}
