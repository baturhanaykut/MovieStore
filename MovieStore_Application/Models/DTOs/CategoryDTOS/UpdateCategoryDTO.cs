using MovieStore_Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore_Application.Models.DTOs.CategoryDTOS
{
    public class UpdateCategoryDTO
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
