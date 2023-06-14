using System.ComponentModel.DataAnnotations;

namespace ApiMovies.Models;

public class Movie
{
    [Key] [Required] public Guid Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [MaxLength(50, ErrorMessage = "Length of Gender cannot bigger than 50 characters.")]
    public string Gender { get; set; }

    [Required(ErrorMessage = "Duration is required")]
    [Range(60, 600, ErrorMessage = "Duration of movie is cannot lower than 60 min and not bigger than 600 min.")]
    public int Duration { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }

    public Movie(string title, string gender, int duration)
    {
        Id = Guid.NewGuid();
        Title = title;
        Gender = gender;
        Duration = duration;
    }
}