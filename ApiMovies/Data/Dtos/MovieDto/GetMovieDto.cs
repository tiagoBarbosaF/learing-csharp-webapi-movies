using ApiMovies.Data.Dtos.SessionDto;

namespace ApiMovies.Data.Dtos.MovieDto;

public class GetMovieDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime TimeConsult { get; set; } = DateTime.Now;
    public ICollection<GetSessionDto> Sessions { get; set; }
}