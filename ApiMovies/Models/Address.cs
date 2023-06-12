using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models;

public class Address
{
    [Key]
    [Required]
    public Guid Id { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public virtual Cinema Cinema { get; set; }
}