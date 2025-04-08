using System.Diagnostics;
using Intro_ASP.NET_Core.Data;
using Intro_ASP.NET_Core.Models;
using Intro_ASP.NET_Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Intro_ASP.NET_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
    
        public HomeController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }
    
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult Privacy()
        {
            return View();
        }
    
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        // POST-метод для обработки отправки формы
        // [HttpPost]
        // [ValidateAntiForgeryToken] // Защита от CSRF
        // public async Task<IActionResult> SubmitContact(ContactFormViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         // Если модель невалидна (например, не заполнены обязательные поля),
        //         // возвращаем ту же View с моделью, чтобы показать ошибки валидации
        //         return View("Index", model); // Укажите имя вашего View, если оно не Index
        //     }
        //
        //     string? uniqueFileName = null;
        //     string? filePath = null;
        //
        //     // --- Обработка загруженного файла ---
        //     if (model.Attachment != null && model.Attachment.Length > 0)
        //     {
        //         try
        //         {
        //             // 1. Определяем папку для сохранения файлов
        //             // Рекомендуется сохранять ВНЕ wwwroot, если к файлам не нужен прямой доступ по URL.
        //             // Если нужен прямой доступ (например, для скачивания), то можно в wwwroot/uploads.
        //             string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", "contact-attachments");
        //
        //             // Убедимся, что папка существует
        //             if (!Directory.Exists(uploadsFolder))
        //             {
        //                 Directory.CreateDirectory(uploadsFolder);
        //             }
        //
        //             // 2. Генерируем уникальное имя файла, чтобы избежать конфликтов
        //             uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Attachment.FileName);
        //             filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //
        //             // 3. Сохраняем файл на диск
        //             using (var fileStream = new FileStream(filePath, FileMode.Create))
        //             {
        //                 await model.Attachment.CopyToAsync(fileStream);
        //             }
        //         }
        //         catch (Exception ex)
        //         {
        //             // Обработка ошибки сохранения файла (логирование, сообщение пользователю)
        //             ModelState.AddModelError("", "Не удалось загрузить файл. Пожалуйста, попробуйте еще раз или свяжитесь с нами.");
        //             // Можно добавить логирование ошибки: _logger.LogError(ex, "File upload failed");
        //             return View("Index", model);
        //         }
        //     }
        //
        //     // --- Сохранение данных в базу данных ---
        //     ContactRequest contactRequest = new ContactRequest
        //     {
        //         Name = model.Name,
        //         Email = model.Email,
        //         Phone = model.Phone,
        //         Message = model.Message,
        //         SubmittedAt = DateTime.UtcNow,
        //         // Сохраняем путь к файлу или null, если файл не был прикреплен
        //         AttachmentPath = filePath
        //     };
        //
        //     try
        //     {
        //         _context.ContactRequests.Add(contactRequest);
        //         await _context.SaveChangesAsync(); // Асинхронно сохраняем изменения в БД
        //
        //         // Опционально: отправить уведомление администратору и т.д.
        //
        //         // Перенаправляем на страницу благодарности или показываем сообщение об успехе
        //         TempData["SuccessMessage"] = "Ваше сообщение успешно отправлено!";
        //         return RedirectToAction("Index"); // Или на другую страницу, например, "ThankYou"
        //         // return View("ThankYou");
        //     }
        //     catch (Exception ex)
        //     {
        //         // Обработка ошибки сохранения в БД (логирование, сообщение пользователю)
        //         ModelState.AddModelError("", "Произошла ошибка при сохранении данных. Пожалуйста, попробуйте позже.");
        //          // Можно добавить логирование ошибки: _logger.LogError(ex, "Database save failed");
        //
        //         // Важно: Если файл уже был сохранен, но БД упала, нужно решить, что делать с файлом.
        //         // Возможно, стоит его удалить, чтобы не накапливать "мусор".
        //         // if (!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath))
        //         // {
        //         //     System.IO.File.Delete(filePath); // Удаляем файл, если запись в БД не удалась
        //         // }
        //
        //         return View("Index", model);
        //     }
        // }
        //
        // // Страница благодарности
        // public IActionResult ThankYou()
        // {
        //     return View();
        // }
    }
}