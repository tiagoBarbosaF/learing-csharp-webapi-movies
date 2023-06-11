using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Data.Dtos.CinemaDto;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "Field Name is required.")]
    public string Name { get; private set; }
}