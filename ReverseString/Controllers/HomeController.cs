using Microsoft.AspNetCore.Mvc;
using ReverseString.Models;
using System.Diagnostics;

namespace ReverseString.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Index(RandomString rString)
        {
            var result = Reverse(rString.Name);
            rString.ReverseName = result;

            return View(rString);
        }
        public static string Reverse(string str)
        {
            if (str.Length > 0)
                return str[str.Length - 1] + Reverse(str.Substring(0, str.Length - 1));
            else
                return str;
        }
        
        //Auto generated code
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