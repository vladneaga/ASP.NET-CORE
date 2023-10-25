using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class HelloWorldController1 : Controller
    {
        public String Index()
        {
            return "This is the index page";
        }

        public String Hello()
        {
            return "Hello";
        }
    }
}
