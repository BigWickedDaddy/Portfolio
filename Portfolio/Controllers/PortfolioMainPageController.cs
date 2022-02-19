using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class PortfolioMainPageController : Controller
    {
        //private readonly ILogger<PortfolioMainPage> _logger;

        //public PortfolioMainPage(ILogger<PortfolioMainPage> logger)
        //{
        //    _logger = logger;
        //}
        public IActionResult Portfolio()
        {
            return View();
        }
    }
}
