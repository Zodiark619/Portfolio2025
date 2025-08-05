using Portfolio2025.Models.Cashier002.ViewModels.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio2025.Models.Cashier002.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId {  get; set; }
        public IEnumerable<Category> Categories { get; set; }=new List<Category>();


        public int SelectedProductId {  get; set; }
        [Display(Name="Quantity")]
        [Range(1,int.MaxValue)]
        //[SalesViewModel_EnsureProperQuantity] need repository fix
        public int QuantityToSell {  get; set; }
    }
}
