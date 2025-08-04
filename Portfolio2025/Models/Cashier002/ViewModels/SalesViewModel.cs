namespace Portfolio2025.Models.Cashier002.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId {  get; set; }
        public IEnumerable<Category> Categories { get; set; }=new List<Category>();
    }
}
