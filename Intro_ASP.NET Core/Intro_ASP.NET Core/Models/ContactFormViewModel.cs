using System.ComponentModel.DataAnnotations;

namespace Intro_ASP.NET_Core.Models
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        [EmailAddress(ErrorMessage = "Некорректный формат E-mail")]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваше сообщение")]
        [Display(Name = "Сообщение")]
        public string Message { get; set; }

        [Required(ErrorMessage = "")]
        [Display(Name = "Дата отправки")]
        public DateTime SubmittedAt { get; set; }
    }
}