using Fiorella.App.Models;

namespace Fiorella.App.ViewModel
{
    public class HomeViewModel
    {
        public ICollection<Category>Categories { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
