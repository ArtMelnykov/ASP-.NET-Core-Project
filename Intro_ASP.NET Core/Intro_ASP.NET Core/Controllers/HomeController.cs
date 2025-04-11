using System.Data.Common;
using System.Diagnostics;
using Intro_ASP.NET_Core.Data;
using Intro_ASP.NET_Core.Models;
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

        [HttpPost]
        public async Task<IActionResult> WorkingWithIFormCollection(ContactFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Set the SubmittedAt property to the current date and time
                    model.SubmittedAt = DateTime.UtcNow;
                    
                    var viewModel = new ContactFormViewModel
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Message = model.Message,
                        SubmittedAt = model.SubmittedAt
                    };
                    
                    
                    // Save the model to the database
                    _context.ContactFormViewModels.Add(viewModel);
                    
                    await _context.SaveChangesAsync();
                    
                    TempData["SuccessMessage"] = "User information saved successfully!";

                    return View(viewModel);
                }
                catch (DbException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            return View(model);
        }
    }
}