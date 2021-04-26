using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/

        public string Index()
        {
            return @"<b>Hello World as a string from Index</b>";
        }

        // GET: /Test/Play
        [HttpGet]
        public string Play()
        {
            // Return a string as a View
            return @"<b>Hello World as a string from Play</b>";
        }

        // GET: /Test/TestView
        [HttpGet]
        public ActionResult TestView()
        {
            // Return a 'TestView.cshtml' (View maps to Action method name)
            return View();
        }

    }
}