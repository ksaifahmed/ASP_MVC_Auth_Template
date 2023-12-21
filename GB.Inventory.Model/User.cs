using GB.Inventory.Model;

namespace GB.Inventory.Model
{
    public class User
    {        
        public long UserId { get; set; }
        public string OfficeId { get; set; } = string.Empty;
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}