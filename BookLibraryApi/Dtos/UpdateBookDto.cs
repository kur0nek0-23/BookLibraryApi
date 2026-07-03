namespace BookLibraryApi.Dtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public List<int> GenreIds { get; set; } = new();
    }
}
