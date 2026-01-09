using System.ComponentModel.DataAnnotations;

namespace TokenBasedAuth.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string UserPassword { get; set; } = string.Empty;
        public bool isActive { get; set; }
    }
}
