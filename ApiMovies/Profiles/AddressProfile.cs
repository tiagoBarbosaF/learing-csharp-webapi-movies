using ApiMovies.Data.Dtos.AddressDto;
using ApiMovies.Models;
using AutoMapper;

namespace ApiMovies.Profiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDto, Address>();

        CreateMap<Address, GetAddressDto>();

        CreateMap<UpdateAddressDto, Address>();
    }
}