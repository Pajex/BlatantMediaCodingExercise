using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GroceryCoConsole.Infrastructure
{
    public class JsonConverter
    {
        /// <summary>
        /// Converts a JSON string to an IList of type T.
        /// </summary>
        /// <typeparam name="T">The object to be returned.</typeparam>
        /// <param name="jsonText">A string containing a JSON object.</param>
        /// <returns>An IList of type T.</returns>
        public static IList<T> ToObject<T>(string jsonText) 
        {
            if (jsonText == null) throw new ArgumentNullException(nameof(jsonText));

            var jObject = JObject.Parse(jsonText);

            var jTokens = jObject["items"].Children().ToList();
            var result = new List<T>();

            foreach (var token in jTokens)
            {
                result.Add(JsonConvert.DeserializeObject<T>(token.ToString()));
            }

            return result;
        }
    }
}