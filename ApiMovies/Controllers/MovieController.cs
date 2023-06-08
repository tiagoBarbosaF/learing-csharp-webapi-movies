using ApiMovies.Data;
using ApiMovies.Data.Dtos;
using ApiMovies.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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

    /// <summary>
    /// Add a movie in database.
    /// </summary>
    /// <param name="movieDto">Object with necessary fields for creating a movie.</param>
    /// <returns>IActionResults</returns>
    /// <response code="201">`If insertion is successful</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);

        _context.Movies.Add(movie);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpGet]
    public IEnumerable<GetMovieDto> GetAllMovies([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<GetMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMovieById(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
            return NotFound();

        var movieDto = _mapper.Map<GetMovieDto>(movie);

        return Ok(movieDto);
    }

    [HttpPut("{id:guid}")]
    public IActionResult PutMovie(Guid id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
            return NotFound();

        _mapper.Map(movieDto, movie);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PatchMovie(Guid id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
            return NotFound();

        var movieForUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieForUpdate, ModelState);

        if (!TryValidateModel(movieForUpdate))
            return ValidationProblem(ModelState);

        _mapper.Map(movieForUpdate, movie);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMovie(Guid id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
            return NotFound();

        _context.Remove(movie);

        _context.SaveChanges();

        return NoContent();
    }
}