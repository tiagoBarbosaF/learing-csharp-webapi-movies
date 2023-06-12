using ApiMovies.Data.Dtos.AddressDto;

namespace ApiMovies.Data.Dtos.CinemaDto;

public class GetCinemaDto
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public GetAddressDto Address { get; set; }
}