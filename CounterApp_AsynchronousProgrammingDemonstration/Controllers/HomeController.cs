using CounterApp_AsynchronousProgrammingDemonstration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace CounterApp_AsynchronousProgrammingDemonstration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static int currentCount = 1;
        static StringBuilder something = new StringBuilder("");

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AsynchronousIncrement()
        {
            string requestUrl = $"https://localhost:7106/api/Counter/IncrementCount/{currentCount}";
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> responseTask = httpClient.GetAsync(requestUrl);
            HttpResponseMessage response = await responseTask;
            currentCount = int.Parse(await response.Content.ReadAsStringAsync());
            return Json(new { counterValue = currentCount });
        }

        [HttpGet]
        public IActionResult SynchronousIncrement()
        {
            string requestUrl = $"https://localhost:7106/api/Counter/IncrementCount/{currentCount}";
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(requestUrl);
            HttpResponseMessage response = httpClient.Send(request);
            currentCount = int.Parse(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            return Json(new { counterValue = currentCount });
        }

        [HttpGet]
        public IActionResult DisplaySomething()
        {
            ViewBag.CurrentCount = currentCount;
            something.AppendLine("Something");
            ViewBag.Something = something.ToString();
            return Json(new { displaySomethingText = something.ToString() });
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
