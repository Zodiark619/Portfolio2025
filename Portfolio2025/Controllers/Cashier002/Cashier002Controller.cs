using Microsoft.AspNetCore.Mvc;
using Portfolio2025.Models;
using Portfolio2025.Models.Cashier002;
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


        public IActionResult SellProductsPartial(int productId)
        {
            var product = context.Products.Find(productId);
            return PartialView("_SellProduct", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            var product=context.Products.Find(salesViewModel.SelectedProductId);
            if (ModelState.IsValid)
            {
                if (product != null)
                {
                   
                    context.Transactions.Add(new Transaction
                    {
                        TimeStamp= DateTime.Now,
                        CashierName="Cashier1",
                        ProductId=salesViewModel.SelectedProductId,
                        ProductName=product.Name,
                        Price=product.Price.HasValue? product.Price.Value : 0,
                        BeforeQty=product.Quantity.HasValue? product.Quantity.Value : 0,
                        SoldQty=salesViewModel.QuantityToSell
                    });
                    product.Quantity-=salesViewModel.QuantityToSell;
                    context.Products.Update(product);
                }
            }

            salesViewModel.SelectedCategoryId = product?.CategoryId==null?0:product.CategoryId.Value;
            salesViewModel.Categories=context.Categories.ToList();
            return View("Index", salesViewModel);
        }


        public IActionResult Transaction()
        {
            var transaction = new TransactionViewModel();
            return View(transaction);
        }
        public IActionResult Search(TransactionViewModel transactionViewModel)
        {
            var transaction = context.Transactions.AsQueryable();


            transaction=transaction.Where(x=>x.CashierName.ToLower().Contains(transactionViewModel.CashierName.ToLower()));
           transaction=transaction.Where(x=>x.TimeStamp<=transactionViewModel.EndDate&&x.TimeStamp>=transactionViewModel.StartDate);
            var result= transaction.ToList();
            transactionViewModel.Transactions= result;
            return View("Transaction",transactionViewModel);
        }
    }
}
