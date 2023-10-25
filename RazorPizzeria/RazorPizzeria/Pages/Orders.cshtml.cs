using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPizzeria.Data;
using RazorPizzeria.Model;

namespace RazorPizzeria.Pages
{
   
    public class OrdersModel : PageModel
    {
        public List<PizzaOrder> PizzaOrders = new List<PizzaOrder>();
        private ApplicationDbContext _context; 
        public OrdersModel(ApplicationDbContext context)
        {
                this._context = context;    
        }
        public void OnGet()
        {
            PizzaOrders = _context.PizzaOrders.ToList();

        }
    }
}
