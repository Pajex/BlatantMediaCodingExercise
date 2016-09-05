using System;
using System.Collections.Generic;
using System.Linq;
using GroceryCoConsole;
using GroceryCoConsole.Model;
using GroceryCoConsole.Service;
using Microsoft.SqlServer.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tests
{
    [TestClass]
    public class GroceryCoTests
    {
        private CheckoutService checkoutService = null;

        [TestMethod]
        public void ParseJSONToPriceCatalogue()
        {
            // arrange
            var priceCatalogueJson =  "{ 'items': [ {'Name': 'pear', 'Price': '2.25' }]}";
            var expected = new Item
            {
                Name = "pear",
                Price = 2.25
            };

            // act
            var jObject = JObject.Parse(priceCatalogueJson);
            var jToken = jObject["items"].Children().ToList();
            var actual = JsonConvert.DeserializeObject<Item>(jToken[0].ToString());

            // assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void JSONToPromotionCatalogue()
        {
            var promotionCatalogueJson = "{ 'flat-sale': [ { 'Name': 'pear', 'SalePrice': '1.50' }]}";
            var expected = new Item
            {
                Name = "pear",
                SalePrice = 1.50
            };


            var jObject = JObject.Parse(promotionCatalogueJson);
            var jToken = jObject["flat-sale"].Children().ToList();
            var actual = JsonConvert.DeserializeObject<Item>(jToken[0].ToString());


            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void CheckoutControllerCheckoutMethodTest()
        {
            // arrange
            var expected = new Receipt
            {
                CheckedOutItems = new List<CheckedOutItem>
                {
                    new CheckedOutItem
                    {
                        Name = "item1",
                        Quantity = 1,
                        Price = .75,
                        SalePrice = .50,
                    },
                    new CheckedOutItem
                    {
                        Name = "item2",
                        Quantity = 2,
                        Price = 2.00
                    }
                }
            };

            var promotionCatalogue = new PromotionCatalogue
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "item1", 
                        SalePrice = .50
                    }
                }
            };

            var priceCatalogue = new PriceCatalogue
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Name = "item1",
                        Price = .75
                    },
                    new Item
                    {
                        Name = "item2",
                        Price = 2.00
                    }
                }
            };

            var shoppingCart = new Queue<string>();
            shoppingCart.Enqueue("item2");
            shoppingCart.Enqueue("item1");
            shoppingCart.Enqueue("item2");
            var actual = new Receipt();

            // act
            foreach (var item in shoppingCart)
            {
                // Item is already in receipt.
                if (actual.CheckedOutItems.Any(x => x.Name == item))
                {
                    actual.CheckedOutItems.FirstOrDefault(x => x.Name == item).Quantity++;
                }
                // New Item to add to receipt.
                else
                {
                    // Search for item in price catalogue.
                    var itemFromPriceCatalogue = priceCatalogue.Items.FirstOrDefault(x => x.Name == item);
                    // Matching item was found in price catalogue.
                    if (itemFromPriceCatalogue != null)
                    {
                        // Create new checked out item to be placed in receipt.
                        var checkedOutItem = new CheckedOutItem
                        {
                            Name = item.ToLower(),
                            Price = itemFromPriceCatalogue.Price, 
                            Quantity = 1
                        };

                        // Search for item in promotion catalgoue.
                        var itemFromPromotionCatalogue = promotionCatalogue.Items.FirstOrDefault(x => x.Name == item);
                        // Matching item was found in promotion catalogue.
                        if (itemFromPromotionCatalogue != null)
                        {
                            // Add Sale Price to CheckedOutItem.
                            checkedOutItem.SalePrice = itemFromPromotionCatalogue.SalePrice;
                        }

                        // Add item to the receipt.
                        actual.CheckedOutItems.Add(checkedOutItem);
                    }
                }
            }
           
            // assert
            Assert.AreEqual(expected.TotalPrice, actual.TotalPrice);
        }
    }
}
