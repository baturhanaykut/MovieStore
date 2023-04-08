using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using MovieStore_Application.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieStore_Domain.Enums;
using MovieStore_Application.Models.VMs.CategoryVM;
using MovieStore_Application.Models.VMs.DirectorVM;
using MovieStore_Application.Models.VMs.LanguageVM;
using MovieStore_Application.Models.VMs.StarringVM;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace MovieStore_Application.Models.DTOs.MovieDTOS
{
    public class CreateMovieDTO
    {
        [Required(ErrorMessage = "Name cannot be null")]
        [MaxLength(50, ErrorMessage = "Name cannot be more than 50 character")]
        [Display(Name = "Name")]
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
        [Range(0, 99999.99, ErrorMessage = "Price must be be between 0-99.999,99.")]
        public decimal? Price { get; set; }

        [Range(10, 1000, ErrorMessage = "Time must be between 10 - 1000 minute")]
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

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }

        public Status Status => Status.Active;

        public List<CategoryVM>? Categories { get; set; }
        public List<DirectorVM>? Directors { get; set; }
        public List<LanguageVM>? Languages { get; set; }
        public List<StarringVM>? Starrings { get; set; }
    }
}
