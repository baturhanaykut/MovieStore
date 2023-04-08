using MovieStore_Domain.Enums;

namespace MovieStore_Domain.Entities

{
    public class Category : IBaseEntity
    {
        public Category()
        {
            Movies = new List<Movie>();
        }
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        //Navigation Property

        public List<Movie>? Movies { get; set; }
        public Status Status { get; set; }
        }
}