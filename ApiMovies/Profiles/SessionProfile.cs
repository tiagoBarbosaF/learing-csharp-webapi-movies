using ApiMovies.Data.Dtos.AddressDto;
using ApiMovies.Data.Dtos.CinemaDto;
using ApiMovies.Data.Dtos.SessionDto;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<CreateSessionDto, Session>();
        CreateMap<Session, GetSessionDto>();
    }
}