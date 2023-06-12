using ApiMovies.Data;
using ApiMovies.Data.Dtos.CinemaDto;
using ApiMovies.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public CinemaController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PutCinema([FromBody] CreateCinemaDto cinemaDto)
    {
        var cinema = _mapper.Map<Cinema>(cinemaDto);

        _context.Cinemas.Add(cinema);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<GetCinemaDto> GetCinemas()
    {
        return _mapper.Map<List<GetCinemaDto>>(_context.Cinemas.ToList());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetCinemaById(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema != null)
        {
            var cinemaDto = _mapper.Map<GetCinemaDto>(cinema);
            return Ok(cinemaDto);
        }

        return NotFound();
    }

    [HttpPut("{id:guid}")]
    public IActionResult PutCinema(Guid id, [FromBody] UpdateCinemaDto cinemaDto)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null)
            return NotFound();

        _mapper.Map(cinemaDto, cinema);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCinema(Guid id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        if (cinema == null)
            return NotFound();

        _context.Remove(cinema);

        _context.SaveChanges();

        return NoContent();
    }
}