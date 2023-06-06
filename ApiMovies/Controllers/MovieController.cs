using ApiMovies.Data;
using ApiMovies.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    // private static List<Movie> _movies = new()
    // {
    //     new Movie("The Matrix", "Action", 136),
    //     new Movie("Inception", "Science Fiction", 148),
    //     new Movie("Pulp Fiction", "Crime", 154),
    //     new Movie("The Shawshank Redemption", "Drama", 142),
    //     new Movie("The Dark Knight", "Action", 152),
    //     new Movie("Fight Club", "Drama", 139),
    //     new Movie("Goodfellas", "Crime", 146),
    //     new Movie("Interstellar", "Science Fiction", 169),
    //     new Movie("The Godfather", "Crime", 175),
    //     new Movie("The Lord of the Rings: The Fellowship of the Ring", "Fantasy", 178)
    // };
    private MovieContext _context;

    public MovieController(MovieContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<Movie> GetAllMovies([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }
}