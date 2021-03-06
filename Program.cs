using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace codeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://127.0.0.1/codetest.json";
            var root = _download_serialized_json_data<Root>(url); 
            
            List<P6> p6 = root.p6;

            foreach(P6 itemP in p6)
            {
                List<Common> common = itemP.common;
                foreach(Common itemC in common)
                {
                    bool required = itemC.required;
                    string name = itemC.name;
                    string md5 = itemC.md5;
                    Console.WriteLine(required.ToString() + " " + name + " " + md5);
                }
            }
        }

         public static T _download_serialized_json_data<T>(string url) where T : new() {
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