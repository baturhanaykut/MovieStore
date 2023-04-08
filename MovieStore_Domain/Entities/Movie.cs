using Microsoft.AspNetCore.Http;
using MovieStore_Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore_Domain.Entities
{
    public class Movie : IBaseEntity
    {

        public Movie()
        {
            Starrings = new List<Starring>();
            //SubTitlesLanguages = new List<Language>();
        }

        public int? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? CategoryId { get; set; }

        public int? DirectorId { get; set; }

        public decimal? Price { get; set; }

        public int? RunningTimeMin { get; set; }

        public int? LanguageId { get; set; }

        public bool? IsActive { get; set; }

        public int? Stock { get; set; }

        public string? ImagePath { get; set; }

        [NotMapped]
        public IFormFile UploadPath { get; set; }


        //Navigation Property
        public Category? Category { get; set; }

        public Director? Director { get; set; }

        public List<Starring>? Starrings { get; set; }
        public Language? Language { get; set; }
        public Status Status { get; set; }
        //public List<Language>? SubTitlesLanguages { get; set; }
    }
}
