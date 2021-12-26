using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Web_Application_with_.net_Core.Models;


namespace Web_Application_with_.net_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GraphServiceClient _graphServiceClient;

        public HomeController(ILogger<HomeController> logger, GraphServiceClient graphServiceClient) // 
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
        }


        public IActionResult Index()
        {
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
