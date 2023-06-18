using ApiMovies.Data.Dtos.AddressDto;
using ApiMovies.Data.Dtos.CinemaDto;
using ApiMovies.Data.Dtos.MovieDto;

namespace ApiMovies.Data.Dtos.SessionDto;

public class GetSessionDto
{
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
}