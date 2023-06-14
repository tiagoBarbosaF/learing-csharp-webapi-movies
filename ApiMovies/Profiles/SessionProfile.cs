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