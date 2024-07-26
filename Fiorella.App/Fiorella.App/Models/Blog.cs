using Fiorella.App.Models.Base_Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorella.App.Models
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image {  get; set; }
        [NotMapped]
        public string Blogurl = "assets/images/blog";
    }
}
