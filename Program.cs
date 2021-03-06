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
            Leaf leaf; 

            var url = "http://127.0.0.1/assetsTree.json";
            var root = downloadSerializedJson<Root>(url); 
            
            List<Common> Lcommon = root.common;
            // List<Fg> Lfg = root.fg;
            List<P6> Lp6 = root.p6;
            var myCount = 0;

            Console.WriteLine(root.p6.Count.ToString());

            foreach(Common itemC in Lcommon){
                List<PtfTerminal> Lptf_Terminal = itemC.ptf_Terminal;
                foreach(PtfTerminal itemPT in Lptf_Terminal)
                {
                    List<Help> Lhelp = itemPT.help;

                    if (itemPT.languages != null){
                        List<Language> Llanguages = itemPT.languages;

                        foreach(Language itemL in Llanguages){
                            leaf = new Leaf(itemL.md5, itemL.name, itemL.required);
                            checkLeaf(leaf);
                        }     
                    }
                }
            }

            foreach(P6 itemP in Lp6)
            {
                /*List<Common> Lcommon2 = itemP.common;
                List<Lang> Llang= itemP.lang;*/
                leaf = new Leaf(itemP.md5, itemP.name, itemP.required);
                checkLeaf(leaf);
                myCount++;
            }
        }

        static bool checkLeaf(Leaf leaf)
        {
            if (leaf.required){
                Console.WriteLine(leaf.required.ToString() + " " + leaf.name + " " + leaf.md5);
                return true;
            }
            return false;
        }

         public static T downloadSerializedJson<T>(string url) where T : new() {
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