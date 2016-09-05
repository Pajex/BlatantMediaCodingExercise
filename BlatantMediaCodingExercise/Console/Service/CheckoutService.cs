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
        /// <summary>
        /// Method which gets the users shopping cart from resources.
        /// </summary>
        /// <param name="shoppingCartRel">The relative path of the shopping-cart.txt file.</param>
        /// <returns>A Queue of strings containing all items within the shopping cart.</returns>
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

        /// <summary>
        /// Method which gets the current price catalogue from resources.
        /// </summary>
        /// <param name="priceCatalogueRel">The relative path of the price-catalogue.json file.</param>
        /// <returns>
        /// A PriceCatalogue object which contains a list of all items stored within
        /// the price-catalogue.json file.
        /// </returns>
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

        /// <summary>
        /// Method which gets the current promotion catalogue from resources.
        /// </summary>
        /// <param name="promotionsRel">The relative path of the promotions.json file.</param>
        /// <returns>
        /// A PromotionCatalogue object which contains a list of all items stored within 
        /// the promotions.json file.
        /// </returns>
        public PromotionCatalogue GetPromotionCatalogue(string promotionsRel)
        {
            var promotionCatalogueJson = File.ReadAllText(promotionsRel);
            if (promotionCatalogueJson == null) throw new ArgumentNullException();

            var jObject = JObject.Parse(promotionCatalogueJson);
            var jToken = jObject["flat-sale"].Children().ToList();
            var result = new List<Item>();

            foreach (var token in jToken)
            {
                var item = JsonConvert.DeserializeObject<Item>(token.ToString());
                //item.OnSale = true;
                result.Add(item);
            }

            return new PromotionCatalogue(result);
        }
    }
}