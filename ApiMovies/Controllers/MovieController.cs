using ApiMovies.Data;
using ApiMovies.Data.Dtos;
using ApiMovies.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreatMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        
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