using GroceryCRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroceryCRUDDemo.Controllers
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
            //Below is a test code to make sure DAL GetAll works. Put @Viewbag.count in View
            //List<Category> cats = DAL.GetAllCategories();
            //ViewBag.count = cats.Count;
            return View();
        }

        public IActionResult Privacy()
        {
            //Just a test for adding creating a new ID automatically
            //Product prod = new Product();
            //prod.name = "Aaa";
            //prod.description = "Aaa test product";
            //prod.price = 1.50m;
            //prod.inventory = 10;
            //prod.category = "FRUIT";
            //Product result = DAL.InsertProduct(prod);
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}