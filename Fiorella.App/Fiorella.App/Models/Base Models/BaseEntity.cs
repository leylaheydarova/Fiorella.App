namespace Fiorella.App.Models.Base_Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
    }
}
