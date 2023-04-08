using MovieStore_Application.Models.VMs.MovieVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieStore_Application.Models.DTOs.DirectorDTOS
{
    public class UpdateDirectorDTO
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "First Name cannnot be null")]
        [MaxLength(30, ErrorMessage = "The maxiumum lengt of first name can be 30 characters")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name cannnot be null")]
        [MaxLength(30, ErrorMessage = "The maxiumum lengt of last name can be 30 characters")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Birth Date cannnot be null")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Directed Movies")]
        public List<Movie>? DirectedMovies { get; set; }
        public Status Statu { get; set; }
        public string FullName => (FirstName + " " + LastName);
    }
}
