using ApiMovies.Data;
using ApiMovies.Data.Dtos.SessionDto;
using ApiMovies.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public SessionController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PutSession(CreateSessionDto sessionDto)
    {
        var session = _mapper.Map<Session>(sessionDto);

        _context.Sessions.Add(session);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetSessionById),
            new { movieId = session.MovieId, cinemaId = session.CinemaId }, session);
    }

    [HttpGet]
    public IEnumerable<GetSessionDto> GetSessions()
    {
        return _mapper.Map<List<GetSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{movieId}/{cinemaId}")]
    public IActionResult GetSessionById(Guid movieId, Guid cinemaId)
    {
        var session =
            _context.Sessions.FirstOrDefault(session => session.MovieId == movieId && session.CinemaId == cinemaId);

        if (session != null)
        {
            var sessionDto = _mapper.Map<GetSessionDto>(session);
            return Ok(sessionDto);
        }

        return NotFound();
    }
}