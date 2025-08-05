using System.ComponentModel.DataAnnotations;

namespace Portfolio2025.Models.Cashier002.ViewModels.Validations
{
    public class SalesViewModel_EnsureProperQuantity:ValidationAttribute
    {
        private readonly DatabaseContext context;

        public SalesViewModel_EnsureProperQuantity(DatabaseContext context)
        {
            this.context = context;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           var salesviewmodel=validationContext.ObjectInstance as SalesViewModel;

            if (salesviewmodel != null)
            {
                if (salesviewmodel.QuantityToSell <= 0)
                {
                    return new ValidationResult("must greater than 0");
                }
                else{
                    var product = context.Products.Find(salesviewmodel.SelectedProductId);

                    if (product != null)
                    {
                        if (product.Quantity < salesviewmodel.QuantityToSell)
                        {
                            return new ValidationResult("not enough quantity in stock");
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
