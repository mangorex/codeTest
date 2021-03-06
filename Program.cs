using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace codeTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var url = "http://127.0.0.1/latest.json";
            var currencyRates = _download_serialized_json_data<CurrencyRates>(url); 
            
            Console.WriteLine(currencyRates.Disclaimer);
            Console.WriteLine(currencyRates.License);
            Console.WriteLine(currencyRates.TimeStamp.ToString());
            Console.WriteLine(currencyRates.Base);

            foreach(KeyValuePair<string, decimal> entry in currencyRates.Rates)
            {
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }

         private static T _download_serialized_json_data<T>(string url) where T : new() {
            using (var w = new WebClient()) {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try {
                json_data = w.DownloadString(url);
                }
                catch (Exception) {}
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
    
}
