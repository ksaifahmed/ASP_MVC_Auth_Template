using GB.Inventory.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GB.Inventory.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        public long UserId { get; set; }
        public string OfficeId { get; set; } = string.Empty;
        public string OfficeName { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}