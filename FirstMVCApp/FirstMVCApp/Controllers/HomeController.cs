using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       static private List<DogViewModel> dogs = new List<DogViewModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(dogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            var dog = new DogViewModel();
            return View(dog);

        }
        public IActionResult CreateDog (DogViewModel dog)
        {
            dogs.Add(dog);  
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remove(string name) 
        {
            var dogToRemove = dogs.FirstOrDefault(dog => dog.Name == name);
            dogs.Remove(dogToRemove);
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}