using Fiorella.App.Models.Base_Models;

namespace Fiorella.App.Models
{
    public class Position:BaseEntity
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
