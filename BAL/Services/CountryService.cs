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
    private readonly HttpService _httpService;
    private readonly CountryDBContext _context;
    private readonly IMapper _mapper;
    public int page = 0;

    public CountryService(HttpService httpService, CountryDBContext context, IMapper mapper)
    {
        _httpService = httpService;
        _context = context;
        _mapper = mapper;
    }
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
            await _context.Countries.AddAsync(dbList.First());
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
            var countriesList = await AllCountries();
            var dbList = _mapper.Map<Country>(countriesList);
            _context.Countries.UpdateRange(dbList);
            await _context.SaveChangesAsync();
            return true;
        }
       catch (Exception exception)
        {
            Console.WriteLine(exception);
            return false;
        }
    }

    public async Task<ListCountriesDTO> GetAllCountries() 
    {
        var listOfCountries = await _context.Countries.OrderBy(n=>n.Name).Skip(page*50).Take(50).ToListAsync();
        page++;

        var result = _mapper.Map<ListCountriesDTO>(listOfCountries);
        return result;
    } 

    public async Task<DbCountryDTO> GetCountriesWithPopulation(string code)
    {
        var listOfCountries = await _context.Countries.Where(c=>c.Code == code).Include(i => i.PopulationCounts).FirstAsync();
        var result = _mapper.Map<DbCountryDTO>(listOfCountries);
        return result;
    }


}
