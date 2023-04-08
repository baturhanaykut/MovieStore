using MovieStore_Domain.Enums;

namespace MovieStore_Domain.Entities
{
    public class Language : IBaseEntity
    {
        public Language()
        {
            OriginalLanguageOfMovies = new List<Movie>();
            //SubtitleLanguageOfMovies = new List<Movie>();
        }


        public int? Id { get; set; }

        public string? Name { get; set; }
        public Status Status { get; set; }

        //NavigationProperty

        public List<Movie>? OriginalLanguageOfMovies { get; set; }
        //public List<Movie>? SubtitleLanguageOfMovies { get; set; }
    }
}