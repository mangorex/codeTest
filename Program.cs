using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json;
using ShellProgressBar;


namespace codeTest
{
    class Program
    {
        static string url = "http://127.0.0.1/";
        static string path = "/home/manu/codeGR/files/";

        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                url = "http://127.0.0.1";
            }
            else
            {
                url = args[0];
            }

            if (!string.IsNullOrWhiteSpace(url))
            {
                var root = downloadSerializedJson<Root>(url);

                loopCommonList(root.common);
                loopFg(root.fg);
                loopP6(root.p6);
            }

        }

        public static bool loopCommonList(List<Common> Lcommon, string commonString1 = "")
        {
            Leaf leaf;
            string path = string.Empty;
            if (string.IsNullOrWhiteSpace(commonString1))
            {
                commonString1 = "archive/";
            }

            commonString1 += "common/";

            string commonString2 = string.Empty;
            try
            {
                foreach (Common itemC in Lcommon)
                {
                    if (itemC.ptf_Terminal != null)
                    {
                        commonString1 += "ptf_Terminal/";
                        foreach (PtfTerminal itemPT in itemC.ptf_Terminal)
                        {
                            if (itemPT.help != null)
                            {
                                commonString2 = commonString1 + "help/";
                                foreach (Help itemHP in itemPT.help)
                                {
                                    leaf = new Leaf(itemHP.md5, itemHP.name, itemHP.required, commonString2);
                                    checkLeaf(leaf);

                                    if (itemHP.en_GB != null)
                                        foreach (EnGB item in itemHP.en_GB)
                                        {
                                            leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "en_GB/");
                                            checkLeaf(leaf);
                                        }
                                }
                            }

                            if (itemPT.languages != null)
                            {
                                commonString2 = commonString1 + "languages/";
                                foreach (Language item in itemPT.languages)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2);
                                    checkLeaf(leaf);
                                }
                            }
                        }
                    }

                    if (itemC.src != null)
                    {
                        commonString2 = commonString1 + "src/";
                        foreach (Src itemSrc in itemC.src)
                        {
                            if (itemSrc.fizzbuzz != null)
                                foreach (Fizzbuzz item in itemSrc.fizzbuzz)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "fizzbuzz/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.campoDeMinas != null)
                                foreach (CampoDeMina item in itemSrc.campoDeMinas)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "campoDeMinas/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.math != null)
                                foreach (Math item in itemSrc.math)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "math/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.leapyear != null)
                                foreach (Leapyear item in itemSrc.leapyear)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "leapyear/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.lcd != null)
                                foreach (Lcd item in itemSrc.lcd)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "lcd/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.stringCalculator != null)
                                foreach (StringCalculator item in itemSrc.stringCalculator)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "stringCalculator/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.statistics != null)
                                foreach (Statistic item in itemSrc.statistics)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "statistics/");
                                    checkLeaf(leaf);
                                }

                            if (itemSrc.fechas != null)
                                foreach (Fecha item in itemSrc.fechas)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "fechas/");
                                    checkLeaf(leaf);
                                }
                        }
                    }

                    if (itemC.explosion != null)
                    {
                        commonString2 = commonString1 + "explosion/";
                        foreach (Explosion item in itemC.explosion)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required, commonString2);
                            checkLeaf(leaf);
                        }
                    }
                    if (itemC.efectos != null)
                    {
                        commonString2 = commonString1 + "efectos/";
                        foreach (Efecto itemEfe in itemC.efectos)
                        {
                            if (itemEfe.bola != null)
                                foreach (Bola item in itemEfe.bola)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "bola/");
                                    checkLeaf(leaf);
                                }
                            if (itemEfe.varios != null)
                                foreach (Vario item in itemEfe.varios)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "varios/");
                                    checkLeaf(leaf);
                                }
                        }
                    }

                    if (itemC.musica != null)
                    {
                        commonString2 = commonString1 + "musica/";
                        foreach (Musica itemMusi in itemC.musica)
                        {
                            leaf = new Leaf(itemMusi.md5, itemMusi.name, itemMusi.required, commonString2);
                            checkLeaf(leaf);

                            if (itemMusi.main_game != null)
                                foreach (MainGame item in itemMusi.main_game)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "main_game/");
                                    checkLeaf(leaf);
                                }
                            if (itemMusi.main_game_results != null)
                                foreach (MainGameResult item in itemMusi.main_game_results)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "main_game_results/");
                                    checkLeaf(leaf);
                                }

                            if (itemMusi.main_game_paytable != null)
                                foreach (MainGamePaytable item in itemMusi.main_game_paytable)
                                {
                                    leaf = new Leaf(item.md5, item.name, item.required, commonString2 + "main_game_paytable/");
                                    checkLeaf(leaf);
                                }
                        }
                    }

                    if (itemC.intro != null)
                        foreach (Intro item in itemC.intro)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required, commonString1 + "intro/");
                            checkLeaf(leaf);
                        }

                    if (itemC.gamePanel != null)
                        foreach (GamePanel item in itemC.gamePanel)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required, commonString1 + "gamePanel/");
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
                        string commonString = "archive/fg/";
                        loopCommonList(itemFg.common, commonString);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool loopLang(List<Lang> Llang, string commonString)
        {
            Leaf leaf;

            try
            {
                foreach (Lang itemLang in Llang)
                {
                    if (itemLang.en != null)
                        foreach (En item in itemLang.en)
                        {
                            leaf = new Leaf(item.md5, item.name, item.required, commonString + "en/");
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
                    string commonString = "archive/p6/";
                    loopCommonList(itemP.common, commonString);
                    loopLang(itemP.lang, commonString);
                    leaf = new Leaf(itemP.md5, itemP.name, itemP.required, commonString);
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
                Console.WriteLine(leaf.md5 + " " + leaf.name + " " + leaf.required.ToString() + " " + leaf.path + leaf.name);
                // Console.WriteLine(url + leaf.path + leaf.name + "         " + path);
                AllDataToDownload allDataDown = new AllDataToDownload(
                    leaf.md5,           // md5
                    url + leaf.path,    // Url to download
                    leaf.name,          // Name file
                    path                // Path to download without structure of folders
                    // path + leaf.path              
                );
                Console.WriteLine("URL Filename: " + allDataDown.urlFile + allDataDown.nameFile + ", pathDownload: " + allDataDown.pathDownload);
                downloadAFileAsync(allDataDown);
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

        public static bool downloadAFileAsync(AllDataToDownload allDataDown)
        {
            try
            {
                bool downloadFile = true;

                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(allDataDown.pathDownload));
                string fullPathName = allDataDown.pathDownload + allDataDown.nameFile;

                if (File.Exists(fullPathName) && allDataDown.md5 == checkMD5(fullPathName))
                    downloadFile = false;

                if (downloadFile)
                {
                    Console.Write("Downloading files... ");
                    using (var webClient = new WebClient())
                    {
                        Console.WriteLine(@"Downloading files. Please wait...");
                        webClient.DownloadFileAsync(
                            new System.Uri(allDataDown.urlFile + allDataDown.nameFile),
                            @"" + fullPathName
                        );
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Was not able to download file!");
                Console.Write(e);
                return false;
            }
            Console.WriteLine("Done.");
            return true;
        }

        public static string checkMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

    }



}