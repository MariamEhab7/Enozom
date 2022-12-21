using AutoMapper;
using Azure;
using BAL.DTOs;
using BAL.Services;
using CountriesPopulation.Interfaces;
using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CountriesPopulation.Services;

public class CountryService : ICountry
{    
    public static int page;

    #region Dependancy Injection
    private readonly HttpService _httpService;
    private readonly CountryDBContext _context;
    private readonly IMapper _mapper;

    public CountryService(HttpService httpService, CountryDBContext context, IMapper mapper)
    {
        _httpService = httpService;
        _context = context;
        _mapper = mapper;
    }
    #endregion
    public async Task<GetCountriesDTO> AllCountries()
    {
        var countries = await _httpService.GetHttpRequest();
        return countries;
    }

    public async Task<bool> AddCountries()
    {
        try
        {
            var jsonObject = await AllCountries();
            var countriesList = jsonObject.data;
            var dbList = _mapper.Map<ICollection<Country>>(countriesList);
            await _context.Countries.AddRangeAsync(dbList);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }
    }

    public async Task<bool> UpdateCountry()
    {
       try
        {
            var jsonObject = await AllCountries();
            var countriesList = jsonObject.data;
            var dbList = _mapper.Map<ICollection<Country>>(countriesList);
            foreach (var country in dbList)
            {
                _context.Countries.Entry(country).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
            return true;
        }
       catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }
    }

    public async Task<ICollection<ListCountriesDTO>> GetAllCountries() 
    {
        var listOfCountries = await _context.Countries.OrderBy(n=>n.Name).Skip(page*50).Take(50).ToListAsync();
        PageCounter();
        var result = _mapper.Map<ICollection<ListCountriesDTO>>(listOfCountries);
        return result;
    } 

    public async Task<DbCountryDTO> GetCountriesWithPopulation(string code)
    {
        var listOfCountries = await _context.Countries.Where(c=>c.Code == code).Include(i => i.PopulationCounts).FirstAsync();
        var result = _mapper.Map<DbCountryDTO>(listOfCountries);
        return result;
    }

    #region Helper Method
    public static void PageCounter()
    {
        Interlocked.Increment(ref page);
    }
    #endregion
}
