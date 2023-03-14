namespace MovieStore.Models.Entities
{
    public class Language
    {
        public Language()
        {
            OriginalLanguageOfMovies = new List<Movie>();
            //SubtitleLanguageOfMovies = new List<Movie>();
        }


        public int? Id { get; set; }

        public string? Name { get; set; }

        //NavigationProperty

        public List<Movie>? OriginalLanguageOfMovies { get; set; }
        //public List<Movie>? SubtitleLanguageOfMovies { get; set; }
    }
}