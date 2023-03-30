using MovieStore_Domain.Enums;

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

        //Not Mapped

        public string FullName => (FirstName + " " + LastName);

        public Status Statu { get; set; }

        //private string fullName;

        //public string FullName
        //{
        //    get { return fullName; }
        //    set { fullName = (FirstName + " " + LastName); }
        //}


    }
}