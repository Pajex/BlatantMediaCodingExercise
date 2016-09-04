namespace GroceryCoConsole.Model
{
    public class CheckedOutItem : Item
    {
        public int Quantity { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Quantity: {Quantity}";
        }
    }
}