using eMovies.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]

        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}