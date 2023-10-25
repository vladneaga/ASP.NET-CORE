using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Model;
using RazorPizzeria.Pages.Forms;

namespace RazorPizzeria.Pages.Checkout
{
    [BindProperties(SupportsGet =true)]
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public string PizzaName { get; set; } = string.Empty;
        public int Price { get; set; } = 0;
        public string ImageTitle { get; set; } = string.Empty;

       public CheckoutModel(ApplicationDbContext context)
        {
            this._context=context;  
        } 
        public void OnGet()
        {

            if (string.IsNullOrWhiteSpace(PizzaName))
            {
                PizzaName = "Custom";
            }
            if (string.IsNullOrWhiteSpace(ImageTitle))
            {
                ImageTitle = "Create";
            }

            PizzaOrder order = new PizzaOrder();
            order.PizzaName = PizzaName;
            order.BasePrice = Price;    
            
            _context.PizzaOrders.Add(order);    
            _context.SaveChanges();
        }
    }
}
