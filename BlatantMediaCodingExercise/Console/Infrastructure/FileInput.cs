using System;
using System.IO;

namespace GroceryCoConsole.Infrastructure
{
    public class FileInput
    {
        public static string ReadFile(string relativePath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(relativePath))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to read file");
                Console.WriteLine(e.Message);
            }

            // TODO: return something more explicit
            return "";
        }

      
    }
}