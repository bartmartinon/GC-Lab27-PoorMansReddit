using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PoorMansReddit.Models;

namespace PoorMansReddit.Controllers
{
    public class HomeController : Controller
    {
        public RedditDAL Context = new RedditDAL();

        public IActionResult Index()
        {
            string output = Context.CallAPI();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RedditPost()
        {
            List<Child> childElements = Context.ConvertToChildElements();
            return View(childElements);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
