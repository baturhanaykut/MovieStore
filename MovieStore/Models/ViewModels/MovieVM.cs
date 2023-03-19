using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MovieStore.Models.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models.ViewModels
{
    public class MovieVM
    {
        public MovieVM()
        {
            Starrings = new List<Starring>();
            AddStarrignsIds = new List<int> ();
            DeleteStarrignsIds = new List<int>();
        }

        public int? Id { get; set; }

        [Required(ErrorMessage ="Name cannot be null")]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 character")]
        [Display(Name="Name")]
        public string? Name { get; set; }
        
        [MaxLength(250, ErrorMessage = "Name cannot be more than 250 character")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Release Date cannot be null")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Catagory Date cannot be null")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Director Date cannot be null")]
        [Display(Name = "Director")]
        public int? DirectorId { get; set; }

        [Required(ErrorMessage = "Price cannot be null")]
        [Display(Name = "Price")]
        [Range(0,99999.99, ErrorMessage ="Price must be be between 0-99.999,99.")]
        public decimal? Price { get; set; }

        [Range(10,1000 ,ErrorMessage = "Time must be between 10 - 1000 minute")]
        [Display(Name = "Running Time Minute")]
        public int? RunningTimeMin { get; set; }

        [Required(ErrorMessage = "Language Id cannot be null")]
        [Display(Name = "Language")]
        public int? LanguageId { get; set; }

       
        [Display(Name = "Is Active ")]
        [ValidateNever]
        public bool IsActive { get; set; }

        [ValidateNever]
        public IFormFile? Image { get; set; }
        [ValidateNever]
        public string? ImagePath { get; set; }
        [ValidateNever]
        [DisplayName("Starrings that can be added")]
        public List<int> AddStarrignsIds { get; set; } 
        [ValidateNever]
        [DisplayName("Current Starrings")]
        public List<int> DeleteStarrignsIds { get; set; }

        [Required(ErrorMessage = "Stock cannot be null")]
        [Display(Name = "Stock")]
        [Range(10, 10000, ErrorMessage = "Stock must be between 0-100.000")]
        public int? Stock { get; set; }

        
        public Category? Category { get; set; }

        public Director? Director { get; set; }

        public List<Starring>? Starrings { get; set; }
        public Language? Language { get; set; }
        
    }
}
