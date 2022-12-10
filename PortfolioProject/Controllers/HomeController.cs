using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System.Diagnostics;

namespace PortfolioProject.Controllers
{
    /// <summary>
    /// The controller for the home page.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        // field
        private readonly ILogger<HomeController> _logger;

        // constructor injection: inject services
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Displays a view of all occasions.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Default privacy page.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}