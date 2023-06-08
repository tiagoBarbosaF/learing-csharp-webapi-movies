using ApiMovies.Data.Dtos;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, GetMovieDto>();
    }
}