using ApiMovies.Data.Dtos.CinemaDto;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();

        CreateMap<Cinema, GetCinemaDto>().ForMember(cinemaDto => cinemaDto.Address,
            opt => opt.MapFrom(cinema => cinema.Address))
            .ForMember(cinemaDto => cinemaDto.Sessions,
                opt => opt.MapFrom(cinema => cinema.Sessions));

        CreateMap<UpdateCinemaDto, Cinema>();
    }
}