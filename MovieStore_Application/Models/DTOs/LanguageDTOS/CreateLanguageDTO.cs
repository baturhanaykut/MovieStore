using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.LanguageDTOS
{
    public class CreateLanguageDTO
    {
        [Required(ErrorMessage = "Name cannnot be null")]
        [MaxLength(30, ErrorMessage = "The maxiumum lengt of name can be 30 characters")]
        public string? Name { get; set; }

        [Display(Name = "Original Language Of Movies")]
        public List<Movie>? OriginalLanguageOfMovies { get; set; }

        public Status Statu { get; set; }
    }
}
