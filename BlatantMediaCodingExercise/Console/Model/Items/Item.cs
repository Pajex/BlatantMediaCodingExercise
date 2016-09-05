namespace GroceryCoConsole.Model
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public bool OnSale => SalePrice > 0.0;

        public override string ToString()
        {
            return $"Name: {Name} Price: {Price} SalePrice: {SalePrice} OnSale: {OnSale}";
        }
    }
}