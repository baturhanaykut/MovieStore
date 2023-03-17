using MovieStore.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieStore.Models.ViewModels
{
    public class CategoryVM
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "Name cannnot be null")]
        [MaxLength(30, ErrorMessage = "The maxiumum lengt of first name can be 30 characters")]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description cannnot be null")]
        [MaxLength(250, ErrorMessage = "The maxiumum lengt of first name can be 250 characters")]
        public string? Description { get; set; }

        //Navigation Property

        public List<Movie>? Movies { get; set; }


    }
}
