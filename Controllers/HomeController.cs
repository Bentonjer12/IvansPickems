using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeBeautify;
using WebappIVAN.Models;

namespace WebappIVAN.Controllers
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

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Root()
        {
            string api_url = "https://score-board-api.herokuapp.com/api/v1/sports/nfl/events";
            string myJsonResponse = RequestApiService(api_url);

            var welcome9 = Welcome9.FromJson(myJsonResponse);
            return View(welcome9);
        }
        public IActionResult ListForm()
        {
            return View();
        }

        public IActionResult FAQs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult SubmitForm()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult SubmitForm(Submit newForm)
        {
            {
                if (ModelState.IsValid)
                {
                    return View("ListForm", newForm);
                }
                else
                {
                    return View();
                }
            }
        }
        [Authorize]
        public IActionResult ViewLeaderboard()
        {
            return View();
        }
        public static string RequestApiService(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();

            }
            catch (WebException ex)
            {
                WebResponse err = ex.Response;
                using (Stream stream = err.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                }
                throw;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public override bool Equals(object obj)
        {
            return obj is HomeController controller &&
                   EqualityComparer<ILogger<HomeController>>.Default.Equals(_logger, controller._logger);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_logger);
        }
    }
}
