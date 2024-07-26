namespace Fiorella.App.Dtos.Blog
{
    public record BlogGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? formFile { get; set; }
    }
}
