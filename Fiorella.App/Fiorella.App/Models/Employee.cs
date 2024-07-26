using Fiorella.App.Models.Base_Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorella.App.Models
{
    public class Employee:BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Image { get; set; }
        public int PositionId { get; set; }
        Position? position { get; set; }
        [NotMapped]
        public string EmployeeURL = "assets/images/employee";
    }
}
