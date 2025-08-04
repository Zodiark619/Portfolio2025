using Microsoft.AspNetCore.Mvc;
using Portfolio2025.Models;
using Portfolio2025.Models.Cashier002.ViewModels;

namespace Portfolio2025.Controllers.Cashier002
{
    public class Cashier002Controller : Controller
    {
        private readonly DatabaseContext context;

        public Cashier002Controller(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var salesviewmodel = new SalesViewModel
            {
                Categories = context.Categories.ToList()    
            };
            return View(salesviewmodel);
        }
    }
}
