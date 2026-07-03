namespace BookLibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public List<Genre> Genres { get; set; } = new();
    }
}
