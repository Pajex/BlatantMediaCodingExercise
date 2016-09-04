using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCoConsole.Infrastructure;
using GroceryCoConsole.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryCoConsole.Service
{
    public class CheckoutService
    {
        public void ProcessCheckout()
        {
            
        }

        public PriceCatalogue GetPriceCatalogue(string priceCatalogueRel) 
        {
            var priceCatalogueJson = FileInput.ReadFile(priceCatalogueRel);
            if (priceCatalogueJson == null) throw new ArgumentNullException();

            var jObject = JObject.Parse(priceCatalogueJson);
            var jToken = jObject["items"].Children().ToList();
            var result = new List<Item>();

            foreach (var token in jToken)
            {
                result.Add(JsonConvert.DeserializeObject<Item>(token.ToString()));
            }

            return new PriceCatalogue(result);
        }

        public PromotionCatalogue GetPromotionalCatalogue(string promotionsRel)
        {
            var promotionCatalogueJson = FileInput.ReadFile(promotionsRel);
            if (promotionCatalogueJson == null) throw new ArgumentNullException();

            var jObject = JObject.Parse(promotionCatalogueJson);
            var jToken = jObject["flat-sale"].Children().ToList();
            var result = new List<Item>();

            foreach (var token in jToken)
            {
                result.Add(JsonConvert.DeserializeObject<Item>(token.ToString()));
            }

            return new PromotionCatalogue(result);
        }
    }
}