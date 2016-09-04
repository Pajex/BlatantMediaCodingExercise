using System.Collections.Generic;

namespace GroceryCoConsole.Model
{
    public abstract class Catalogue
    {
        public IList<Item> Items { get; set; }
    }
}