using iCreateTikTok.Helpers;
using iCreateTikTok.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace iCreateTikTok.Controllers
{
    public class HomeController : Controller
    {
        private const string ACCESS_TOKEN = "ACCESS_TOKEN";
        private const string BASE_URL = "https://ads.tiktok.com/open_api/v1.3/page/lead/task/";
        private const string ADVERTISER_ID = "ADVERTISER_ID";
        private const string PAGE_ID = "PAGE_ID";

        public IActionResult Index()
        {
            try
            {
                var data = TikTokAPI.GetDataAsync(ACCESS_TOKEN, BASE_URL, ADVERTISER_ID, PAGE_ID);
                string json = data.GetAwaiter().GetResult();
                JavaScriptSerializer js = new JavaScriptSerializer();
                LeadItem[] items = js.Deserialize<LeadItem[]>(json);
                ViewData["data"] = items;
            }
            catch (Exception ex)
            {
                ViewData["data"] = false;
                ViewBag.msg = ex.Message;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}