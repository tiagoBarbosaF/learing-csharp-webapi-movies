using ApiMovies.Data.Dtos;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreatMovieDto, Movie>();
    }
}