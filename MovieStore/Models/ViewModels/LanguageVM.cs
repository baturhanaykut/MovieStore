using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Models.ViewModels
{
    public class LanguageVM
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name cannnot be null")]
        [MaxLength(30, ErrorMessage = "The maxiumum lengt of name can be 30 characters")]
        public string? Name { get; set; }

        [Display(Name = "Original Language Of Movies")]
        public List<Movie>? OriginalLanguageOfMovies { get; set; }
        //public List<Movie>? SubtitleLanguageOfMovies { get; set; }
    }
}
