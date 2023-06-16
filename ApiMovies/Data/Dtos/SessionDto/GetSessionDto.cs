namespace ApiMovies.Data.Dtos.SessionDto;

public class GetSessionDto
{
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
}