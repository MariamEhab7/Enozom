
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

		CreateMap<PopulationDTO, PopulationCount>();

		CreateMap<Country, DbCountryDTO>();

		CreateMap<Country, ListCountriesDTO>();
	}
}
