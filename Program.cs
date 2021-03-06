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
            var url = "http://127.0.0.1/assetsTree.json";
            var root = _download_serialized_json_data<Root>(url); 
            
            List<Common> Lcommon = root.common;
            // List<Fg> Lfg = root.fg;
            List<P6> Lp6 = root.p6;
            var myCount = 0;

            Console.WriteLine(root.p6.Count.ToString());

            foreach(Common itemC in Lcommon){
                List<PtfTerminal> Lptf_Terminal = itemC.ptf_Terminal;
                foreach(PtfTerminal itemPT in Lptf_Terminal)
                {
                    /*List<object> Lskins = itemPT.skins;
                    List<Help> Lhelp = itemPT.help;*/

                    if (itemPT.languages != null){
                        List<Language> Llanguages = itemPT.languages;

                        foreach(Language itemL in Llanguages){
                            bool required = itemL.required;

                            if (required){
                                string name = itemL.name;
                                string md5 = itemL.md5;
                                Console.WriteLine(required.ToString() + " " + name + " " + md5);
                            }
                        }     
                    }
                    
                }
            }

            foreach(P6 itemP in Lp6)
            {
                /*List<Common> Lcommon2 = itemP.common;
                List<Lang> Llang= itemP.lang;*/
                bool required = itemP.required;

                if (required){
                    string name = itemP.name;
                    string md5 = itemP.md5;
                    Console.WriteLine(required.ToString() + " " + name + " " + md5 + ", element: " + myCount);
                }

                /*foreach(Common itemC in Lcommon2)
                {
                    bool required = itemC.required;
                    string name = itemC.name;
                    string md5 = itemC.md5;
                    Console.WriteLine(required.ToString() + " " + name + " " + md5);
                }*/

                myCount++;
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