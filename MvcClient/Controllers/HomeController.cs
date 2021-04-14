using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcClient.Models;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var _http = new HttpClient();
            _http.SetBearerToken(token);
            _http.BaseAddress = new Uri("https://localhost:5001");

            var resp = await _http.GetAsync("test");
            string result = "authorize";
            if (resp.IsSuccessStatusCode)
            {
                result = await resp.Content.ReadAsStringAsync();
            }
            ViewBag.Msg = result;
            return View();
        }

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
