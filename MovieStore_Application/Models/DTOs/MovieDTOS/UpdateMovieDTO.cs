using Microsoft.AspNetCore.Http;
using MovieStore_Application.Extension;
using MovieStore_Application.Models.VMs.CategoryVM;
using MovieStore_Application.Models.VMs.DirectorVM;
using MovieStore_Application.Models.VMs.LanguageVM;
using MovieStore_Application.Models.VMs.StarringVM;
using MovieStore_Domain.Entities;
using MovieStore_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Application.Models.DTOs.MovieDTOS
{
    public class UpdateMovieDTO
    {
        public Status Status => Status.Active;

        public string ImagePath { get; set; }

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }

        public List<CategoryVM>? Categories { get; set; }
        public List<DirectorVM>? Directors { get; set; }
        public List<LanguageVM>? Languages { get; set; }
        public List<StarringVM>? Starrings { get; set; }

        
    }
}
