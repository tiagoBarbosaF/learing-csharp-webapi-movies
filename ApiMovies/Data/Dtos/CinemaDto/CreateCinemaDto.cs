using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Data.Dtos.CinemaDto;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "Field Name is required.")]
    public string Name { get; private set; }
}