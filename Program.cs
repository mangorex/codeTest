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
            var root = downloadSerializedJson<Root>(url);

            List<Common> Lcommon = root.common;
            List<Fg> Lfg = root.fg;
            List<P6> Lp6 = root.p6;

            loopCommonList(Lcommon);
            loopFg(Lfg);
        }

        public static bool loopCommonList(List<Common> Lcommon)
        {
            Leaf leaf;

            try
            {
                foreach (Common itemC in Lcommon)
                {
                    if (itemC.ptf_Terminal != null)
                    {
                        foreach (PtfTerminal itemPT in itemC.ptf_Terminal)
                        {
                            if (itemPT.help != null)
                            {
                                foreach (Help itemHP in itemPT.help)
                                {
                                    if (itemHP.en_GB != null)
                                        foreach (EnGB item in itemHP.en_GB)
                                        {
                                            leaf = new Leaf(item.md5, item.name, item.required);
                                            checkLeaf(leaf);
                                        }

                                    leaf = new Leaf(itemHP.md5, itemHP.name, itemHP.required);
                                    checkLeaf(leaf);
                                }
                            }

                            if (itemPT.languages != null)
                                foreach (Language item in itemPT.languages)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                        }
                    }
                    if (itemC.src != null)
                    {
                        foreach (Src itemSrc in itemC.src)
                        {
                            if (itemSrc.fizzbuzz != null)
                                foreach (Fizzbuzz item in itemSrc.fizzbuzz)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.campoDeMinas != null)
                                foreach (CampoDeMina item in itemSrc.campoDeMinas)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.math != null)
                                foreach (Math item in itemSrc.math)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.leapyear != null)
                                foreach (Leapyear item in itemSrc.leapyear)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.lcd != null)
                                foreach (Lcd item in itemSrc.lcd)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.stringCalculator != null)
                                foreach (StringCalculator item in itemSrc.stringCalculator)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.statistics != null)
                                foreach (Statistic item in itemSrc.statistics)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.fechas != null)
                                foreach (Fecha item in itemSrc.fechas)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool loopFg(List<Fg> LFg)
        {
            Leaf leaf;

            try
            {
                foreach (Fg itemFg in LFg)
                {
                    if (itemFg.common != null)
                    {
                        loopCommonList(itemFg.common);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool loopP6(List<P6> Lp6)
        {
            Leaf leaf;

            try
            {
                foreach (P6 itemP in Lp6)
                {
                    /*List<Common> Lcommon2 = itemP.common;
                    List<Lang> Llang= itemP.lang;*/
                    leaf = new Leaf(itemP.md5, itemP.name, itemP.required);
                    checkLeaf(leaf);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        static bool checkLeaf(Leaf leaf)
        {
            if (leaf.required)
            {
                Console.WriteLine(leaf.md5 + " " + leaf.name + " " + leaf.required.ToString());
                return true;
            }
            return false;
        }

        public static T downloadSerializedJson<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }

}