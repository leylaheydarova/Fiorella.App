namespace Fiorella.App.Dtos.Blog
{
    public record BlogPostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? formFile { get; set; }
    }
}
