using System.ComponentModel.DataAnnotations;

namespace Intro_ASP.NET_Core.ViewModel
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Пожалуйста, введите ваше имя")]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваш E-mail")]
        [EmailAddress(ErrorMessage = "Некорректный формат E-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        [Display(Name = "Телефон")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите ваше сообщение")]
        [Display(Name = "Сообщение")]
        public string Message { get; set; }

        [Display(Name = "Прикрепить файл")]
        // Можно добавить валидацию на размер или тип файла, если нужно
        // [AllowedExtensions(new string[] { ".jpg", ".png", ".pdf" })]
        // [MaxFileSize(5 * 1024 * 1024)] // Например, 5 MB
        public IFormFile? Attachment { get; set; } // Свойство для файла (nullable, если файл не обязателен)
    }
}