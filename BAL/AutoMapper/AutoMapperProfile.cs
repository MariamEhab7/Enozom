
using AutoMapper;
using BAL.DTOs;
using DAL.Models;

namespace BAL.AutoMapper;

public class AutoMapperProfile : Profile
{
	public AutoMapperProfile()
	{
		CreateMap<GetCountriesDTO, DbCountryDTO>();
		CreateMap<CountryDTO, Country>();
		CreateMap<Country, CountryDTO>();

		CreateMap<PopulationDTO, PopulationCount>();
		CreateMap<PopulationCount, PopulationDTO>();

		CreateMap<Country, DbCountryDTO>();
		CreateMap<Country, ListCountriesDTO>();
	}
}
