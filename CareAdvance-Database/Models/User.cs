using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CareAdvance_Database.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string? Username { get; set; } = String.Empty;
        public string? FirstName { get; set; } = String.Empty;
        public string? LastName { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
