using Microsoft.AspNetCore.Mvc;

namespace Portfolio2025.Models.Cashier002
{
    [ViewComponent]
    public class TransactionsViewComponent:ViewComponent
    {
        private readonly DatabaseContext context;

        public TransactionsViewComponent(DatabaseContext context)
        {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            var transaction = context.Transactions.ToList();
            return View(transaction);
        }
    }
}
