namespace BookLibraryApi.Dtos
{
    // Dtos/BookDto.cs
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public List<string> Genres { get; set; } = new();
    }
}
