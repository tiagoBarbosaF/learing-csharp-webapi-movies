using ApiMovies.Data.Dtos.CinemaDto;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();

        CreateMap<Cinema, GetCinemaDto>();

        CreateMap<UpdateCinemaDto, Cinema>();
    }
}