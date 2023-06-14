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

        return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
    }

    [HttpGet]
    public IEnumerable<GetSessionDto> GetSessions()
    {
        return _mapper.Map<List<GetSessionDto>>(_context.Sessions.ToList());
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetSessionById(Guid id)
    {
        var session = _context.Sessions.FirstOrDefault(session => session.Id == id);

        if (session != null)
        {
            var sessionDto = _mapper.Map<GetSessionDto>(session);
            return Ok(sessionDto);
        }

        return NotFound();
    }
}