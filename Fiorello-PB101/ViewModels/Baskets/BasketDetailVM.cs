using Fiorello_PB101.Models;

namespace Fiorello_PB101.ViewModels.Baskets
{
    public class BasketDetailVM
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public decimal Price { get; set; }
        //public string Description { get; set; }
        //public string Category { get; set; }
        //public ICollection<ProductImage> ProductImages { get; set; }
        //public int Count { get; set; }
        public List<BasketProductVM> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalCount { get; set; }
    }
}
