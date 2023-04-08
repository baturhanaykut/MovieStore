using MovieStore_Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore_Domain.Entities

{
    public class Director : IBaseEntity
    {
        public Director()
        {
            DirectedMovies = new List<Movie>();
        }
        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        //Navigation Property

        public List<Movie>? DirectedMovies { get; set; }

        
        [NotMapped]
        public string FullName => (FirstName + " " + LastName);

        public Status Status { get; set; }

        
    }
}