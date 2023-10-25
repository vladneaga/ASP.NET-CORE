using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Model;


namespace RazorPizzeria.Pages.Forms
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class CustomPizzaModel : PageModel
    {
        [BindProperty]
       public  PizzasModel Pizza { get; set; }
        public float PizzaPrice { get; set; }   


        public void OnGet()
        {
            Pizza = new PizzasModel();
            Console.WriteLine("Here" + Pizza.BasePrice);
           
            //return RedirectToPage("/Checkout/Checkout", new { PizzaName = Pizza.PizzaName, Price = PizzaPrice });
        }

        public IActionResult OnPost() 
        {
            Console.WriteLine("HerePost");
            PizzaPrice = Pizza.BasePrice;
            if (Pizza.TomatoSauce) PizzaPrice += 1;
            if (Pizza.Cheese) PizzaPrice += 1;
            if (Pizza.Ham) PizzaPrice += 1;
            if (Pizza.Beef) PizzaPrice += 1;
            if (Pizza.Mushroom) PizzaPrice += 1;
            if (Pizza.Peperoni) PizzaPrice += 1;

            return RedirectToPage("/Checkout/Checkout", new { PizzaName = Pizza.PizzaName, Price = PizzaPrice });
        }
        
    }
}
