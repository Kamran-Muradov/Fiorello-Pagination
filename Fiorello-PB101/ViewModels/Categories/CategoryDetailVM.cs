namespace Fiorello_PB101.ViewModels.Categories
{
    public class CategoryDetailVM
    {
        public string Name { get; set; }
        public string CreatedDate { get; set; }
        public ICollection<string> Products { get; set; }
        public int ProductCount { get; set; }
    }
}
