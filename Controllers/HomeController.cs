using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using System.Diagnostics;
using System.Xml.Linq;
using TestNode.Models;

namespace TestNode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly INodeServices _nodeServices;

        public HomeController(ILogger<HomeController> logger, INodeServices nodeServices)
        {
            _logger = logger;
            _nodeServices = nodeServices;
        }

        public IActionResult Index()
        {
            var name = new Name()
            {
                TheName = ""
            };

            return View(name);
        }
        
        
           
        

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] Name Data)
        {
            var newData = new Name();

            if (ModelState.IsValid)
            {
                string thename = await _nodeServices.InvokeAsync<string>("NodeScripts/Senitizer.js", Data.TheName);
                newData.TheName = thename;
                return View(newData);
            }

            return View(Data);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}