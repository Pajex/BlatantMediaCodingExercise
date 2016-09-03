using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GroceryCoConsole.Infrastructure;
using GroceryCoConsole.Model;
using GroceryCoConsole.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = GroceryCoConsole.Infrastructure.JsonConverter;

namespace GroceryCoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string catalogueText = FileInput.ReadFile("../../Resources/price-catalogue.json");

            Output.MainScreen();


        }
    }
}
