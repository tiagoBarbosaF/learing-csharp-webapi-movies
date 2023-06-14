using ApiMovies.Data.Dtos.MovieDto;
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
        CreateMap<Movie, GetMovieDto>()
            .ForMember(movieDto => movieDto.Sessions, 
                opt => opt.MapFrom(movie => movie.Sessions));
    }
}