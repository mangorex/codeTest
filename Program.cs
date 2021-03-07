using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace codeTest
{
    class Program
    {
        static string url = "http://127.0.0.1/assetsTree.json";
        static string route = "/home/manu/codeGR/";

        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                url = "http://127.0.0.1/assetsTree.json";
            }else {
                url = args[0];
                // downloadAFileNoAsync(url, args[1]);
            }

            if (!string.IsNullOrWhiteSpace(url))
            {
                var root = downloadSerializedJson<Root>(url);

                loopCommonList(root.common);
                loopFg(root.fg);
                loopP6(root.p6);
            }

        }

        public static bool loopCommonList(List<Common> Lcommon)
        {
            Leaf leaf;
            string route = string.Empty;

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
                                            leaf = new Leaf(item.md5, item.name, item.required, "common/ptf_Terminal/help/en_GB");
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

                    if (itemC.explosion != null)
                        foreach (Explosion item in itemC.explosion)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required);
                            checkLeaf(leaf);
                        }

                    if (itemC.efectos != null)
                    {
                        foreach (Efecto itemEfe in itemC.efectos)
                        {
                            if (itemEfe.bola != null)
                                foreach (Bola item in itemEfe.bola)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                            if (itemEfe.varios != null)
                                foreach (Vario item in itemEfe.varios)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                        }
                    }

                    if (itemC.musica != null)
                    {
                        foreach (Musica itemMusi in itemC.musica)
                        {
                            if (itemMusi.main_game != null)
                                foreach (MainGame item in itemMusi.main_game)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                            if (itemMusi.main_game_results != null)
                                foreach (MainGameResult item in itemMusi.main_game_results)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }

                            leaf = new Leaf(itemMusi.md5, itemMusi.name, itemMusi.required);
                            checkLeaf(leaf);

                            if (itemMusi.main_game_paytable != null)
                                foreach (MainGamePaytable item in itemMusi.main_game_paytable)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required);
                                    checkLeaf(leaf);
                                }
                        }
                    }

                    if (itemC.intro != null)
                        foreach (Intro item in itemC.intro)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required);
                            checkLeaf(leaf);
                        }

                    if (itemC.gamePanel != null)
                        foreach (GamePanel item in itemC.gamePanel)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required);
                            checkLeaf(leaf);
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

        public static bool loopLang(List<Lang> Llang)
        {
            Leaf leaf;

            try
            {
                foreach (Lang itemLang in Llang)
                {
                    if (itemLang.en != null)
                        foreach (En item in itemLang.en)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required);
                            checkLeaf(leaf);
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
                    loopCommonList(itemP.common);
                    loopLang(itemP.lang);
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
                Console.WriteLine(leaf.md5 + " " + leaf.name + " " + leaf.required.ToString() + " " + leaf.route + "/" + leaf.name);
                Console.WriteLine(url + leaf.route + "/" + leaf.name + " " + route);
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
                    json_data = w.DownloadString(url + "assetsTree.json");
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }

        public static bool downloadAFileNoAsync(string url="", string route = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                    url = "http://127.0.0.1/common/ptf_Terminal/help/en_GB/";

                if (string.IsNullOrWhiteSpace(route))
                    route = "/home/manu/codeGR/";

                using (var webClient = new WebClient())
                {
                    webClient.DownloadFile(url + "keno.html", @""+route + "keno.html");
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }

}