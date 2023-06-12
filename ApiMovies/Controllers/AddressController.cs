using ApiMovies.Data;
using ApiMovies.Data.Dtos.AddressDto;
using ApiMovies.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiMovies.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public AddressController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PutAddress([FromBody] CreateAddressDto addressDto)
    {
        var address = _mapper.Map<Address>(addressDto);

        _context.Addresses.Add(address);

        _context.SaveChanges();

        return CreatedAtAction(nameof(GetAddressById), new { id = address.Id }, address);
    }

    [HttpGet]
    public IEnumerable<GetAddressDto> GetAddress()
    {
        return _mapper.Map<List<GetAddressDto>>(_context.Addresses);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAddressById(Guid id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address != null)
        {
            var addressDto = _mapper.Map<GetAddressDto>(address);

            return Ok(addressDto);
        }

        return NotFound();
    }

    [HttpPut("{id:guid}")]
    public IActionResult PutAddress(Guid id, [FromBody] UpdateAddressDto addressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null)
            return NotFound();

        _mapper.Map(addressDto, address);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAddress(Guid id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address == null)
            return NotFound();

        _context.Remove(address);

        _context.SaveChanges();

        return NoContent();
    }
}