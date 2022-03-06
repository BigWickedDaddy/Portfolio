using Microsoft.AspNetCore.Mvc;
using Misc.Services.EmailService;
using Misc.Services.EmailService.Models;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmailService? _emailService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SendGmail(string name, string email, string mobileNumber, string formMessage)
        {
            EmailModel emailModel = new EmailModel
            {
                name = name,
                email = email,
                mobileNumber = mobileNumber,
                message = formMessage
            };

            _emailService = new EmailService();
            _emailService.SendGmail(emailModel);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}