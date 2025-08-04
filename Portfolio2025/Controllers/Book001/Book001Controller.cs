using Microsoft.AspNetCore.Mvc;
using Portfolio2025.Models.Book001;

namespace Portfolio2025.Controllers.Book001
{
    public class Book001Controller : Controller
    {
        public IActionResult Detail(int id)
        {
            Book book = DB.GetBook(id);
            return View(book);
        }

        public IActionResult List()
        {
            List<Book> books = DB.LoadBooks();
            return View(books);
        }
    }
}
