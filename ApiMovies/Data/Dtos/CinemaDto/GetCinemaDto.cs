using ApiMovies.Data.Dtos.AddressDto;
using ApiMovies.Data.Dtos.SessionDto;

namespace ApiMovies.Data.Dtos.CinemaDto;

public class GetCinemaDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public GetAddressDto Address { get; set; }
    public DateTime TimeConsult { get; set; } = DateTime.Now;
    public ICollection<GetSessionDto> Sessions { get; set; }
}