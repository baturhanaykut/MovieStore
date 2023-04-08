using MovieStore_Domain.Enums;

namespace MovieStore_Domain.Entities
{
    public class Starring : IBaseEntity
    {
        public Starring()
        {
            PerformedMovies = new List<Movie>();
        }

        public int? Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        //Navigation Property
        public List<Movie>? PerformedMovies { get; set; }

        //Not Mapp
        public string FullName => (FirstName + " " + LastName);

        public Status Status { get; set; }
    }
}