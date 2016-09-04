using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GroceryCoConsole.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryCoConsole.Service
{
    public class CheckoutService
    {
        public Queue<string> GetShoppingCart(string shoppingCartRel)
        {
            var shoppingCart = File.ReadAllLines(shoppingCartRel);
            if (shoppingCart == null) throw new ArgumentNullException();

            var result = new Queue<string>();

            foreach (var item in shoppingCart)
            {
                result.Enqueue(item);
            }

            return result;

        }

        public PriceCatalogue GetPriceCatalogue(string priceCatalogueRel)
        {
            var priceCatalogueJson = File.ReadAllText(priceCatalogueRel);
            if (priceCatalogueJson == null) throw new ArgumentNullException();

            var jObject = JObject.Parse(priceCatalogueJson);
            var jToken = jObject["items"].Children().ToList();
            var result = new List<Item>();

            foreach (var token in jToken)
            {
                var item = JsonConvert.DeserializeObject<Item>(token.ToString());
                result.Add(item);
            }

            return new PriceCatalogue(result);
        }

        public PromotionCatalogue GetPromotionalCatalogue(string promotionsRel)
        {
            var promotionCatalogueJson = File.ReadAllText(promotionsRel);
            if (promotionCatalogueJson == null) throw new ArgumentNullException();

            var jObject = JObject.Parse(promotionCatalogueJson);
            var jToken = jObject["flat-sale"].Children().ToList();
            var result = new List<Item>();

            foreach (var token in jToken)
            {
                var item = JsonConvert.DeserializeObject<Item>(token.ToString());
                item.OnSale = true;
                result.Add(item);
            }

            return new PromotionCatalogue(result);
        }
    }
}