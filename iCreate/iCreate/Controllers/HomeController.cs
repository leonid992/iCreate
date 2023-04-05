using iCreate.Helpers;
using iCreate.Hubs;
using iCreate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;

namespace iCreate.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserCodes _userCodes;
        
        public HomeController(UserCodes userCodes)
        {
            _userCodes = userCodes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserCode()
        {
            return View();
        }

        public IActionResult CheckCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckCode(string code)
        {
            int c;
            if (!Int32.TryParse(code, out c))
            {
                return Json("Invalid Code!");
            }
            if (!_userCodes.randomCodes.Contains(c))
            {
                return Json("Code is not in the list!");
            }
            if (!_userCodes.codesList.Contains(c))
            {
                return Json("Code is not assigned to any user!");
            }
            return Json("Code is available!");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}