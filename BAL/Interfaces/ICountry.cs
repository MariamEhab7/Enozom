using BAL.DTOs;

namespace CountriesPopulation.Interfaces;

public interface ICountry
{
    Task<GetCountriesDTO> AllCountries();
    Task<bool> AddCountries();
    Task<bool> UpdateCountry();
    Task<ListCountriesDTO> GetAllCountries();
    Task<DbCountryDTO> GetCountriesWithPopulation(string code);

}
