using System.ComponentModel.DataAnnotations;

namespace Intro_ASP.NET_Core.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(20)]
        public string? Phone { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        
        public string? AttachmentPath { get; set; }
    }
}