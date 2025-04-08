using System.ComponentModel.DataAnnotations;

namespace Intro_ASP.NET_Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; } // Primary Key
        [Required]
        public string Name { get; set; } // Required field
        public int DisplayOrder { get; set; } // Display Order
    }
}