namespace ApiMovies.Data.Dtos.SessionDto;

public class CreateSessionDto
{
    public Guid MovieId { get; set; }
    public Guid CinemaId { get; set; }
}