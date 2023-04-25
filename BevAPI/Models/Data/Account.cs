using System.ComponentModel.DataAnnotations.Schema;

namespace BevAPI.Models.Data
{
    public class Account
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [NotMapped]
        public string? Token { get; set; }
    }
}