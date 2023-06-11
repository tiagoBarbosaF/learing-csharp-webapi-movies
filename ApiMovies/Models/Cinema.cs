using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models;

public class Cinema
{
    [Key]
    [Required]
    public Guid Id { get; private set; }
    
    [Required(ErrorMessage = "Field Name is required.")]
    public string Name { get; private set; }
}