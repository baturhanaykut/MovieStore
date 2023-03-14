namespace MovieStore.Entities
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //NavigationProperty

        public List<Movie> OriginalLanguageOfMovies { get; set; }
        public List<Movie> SubtitleLanguageOfMovies { get; set; }
    }
}