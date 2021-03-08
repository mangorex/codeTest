using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Threading;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace codeTest
{
    public class DownloadOBJ
    {
        public bool Req { get; set; }
        public string Basepath { get; set; }
        public string Name { get; set; }
        public string md5 { get; set; }

        public DownloadOBJ()
        {

        }

        public DownloadOBJ(bool Req, string Basepath, string Name, string md5)
        {
            this.Req = Req;
            this.Basepath = Basepath;
            this.Name = Name;
            this.md5 = md5;
        }

        public override string ToString()
        {
            return "Req: " + Req.ToString() + ", Basepath: " + Basepath +
             ", Name: " + Name  + ", md5: " + md5;
        }
    }

    public class Program
    {
        public static List<DownloadOBJ> ListDownload = new List<DownloadOBJ>();
        static string url = "";
        static string fileJson = "";
        static string pathToDownload = "";

        public static void Main(string[] args)
        {
            url = (
                args.Length != 0 && Uri.IsWellFormedUriString(
                    args[0], UriKind.Absolute
                ) ? args[0]: "http://127.0.0.1/"
            );
            fileJson = (args.Length > 2  ? args[1]: "assetsSimple.json");
            pathToDownload = (args.Length > 2 ? args[2]: "/home/manu/codeGR/files/");

            if (!string.IsNullOrWhiteSpace(url))
            {
                using (var w = new WebClient())
                {
                    // attempt to download JSON data as a string
                    try
                    {
                        var json_data = w.DownloadString(url + fileJson);
                        Dictionary<string, object> des = 
                            JsonConvert.DeserializeObject<Dictionary<string, object>>(json_data);

                        foreach (KeyValuePair<string, object> kv in des)
                        {
                            IterateKeyValue(kv.Key, kv.Value, kv.Key.ToString());
                        }

                        Console.WriteLine(@"Downloading files. Please wait...");

                        foreach (DownloadOBJ elemDownObj in ListDownload)
                        {
                            // Console.WriteLine(elemDownObj.ToString());
                            downloadAFileAsync(elemDownObj);
                        }

                        Console.WriteLine("Done.");

                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private static void IterateKeyValue(string key, object value, string basepath)
        {
            if (value.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
            {
                Newtonsoft.Json.Linq.JToken[] value2 = (
                    (Newtonsoft.Json.Linq.JArray)value
                    )[0].ToArray();
                List<object> valueList = JsonConvert.DeserializeObject<List<object>>(
                    ((Newtonsoft.Json.Linq.JArray)value).ToString());

                foreach (var child in valueList)
                {
                    bool isLeaf = false;
                    Dictionary<string, object> childDic = 
                        JsonConvert.DeserializeObject<Dictionary<string, object>>(child.ToString());
                        
                    foreach (KeyValuePair<string, object> kv in childDic)
                    {
                        if (kv.Value.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                        {
                            IterateKeyValue(kv.Key, kv.Value, Path.Combine(basepath, kv.Key));
                        }
                        else
                        {
                            isLeaf = true;
                        }
                    }
                    if (isLeaf)
                    {
                        DownloadOBJ dobj = new DownloadOBJ();
                        dobj.Name = (string)childDic["name"];
                        dobj.Req = bool.Parse(childDic["required"].ToString());
                        dobj.Basepath = basepath;
                        dobj.md5 = (string)childDic["md5"];
                        ListDownload.Add(dobj);
                    }
                }
            }
        }

        public static bool downloadAFileAsync(DownloadOBJ downloadObj)
        {
            try
            {
                bool downloadFile = true;

                string pathDownloadBase = @"" + pathToDownload + downloadObj.Basepath;
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(pathDownloadBase));
                string fullPathName = pathToDownload + downloadObj.Basepath + downloadObj.Name;

                if (File.Exists(fullPathName) && downloadObj.md5 == checkMD5(fullPathName))
                    downloadFile = false;

                if (downloadFile)
                {
                    using (var webClient = new WebClient())
                    {
                        webClient.DownloadFileAsync(
                            new System.Uri(url + downloadObj.Basepath + "/" + downloadObj.Name),
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
            return true;
        }

        public static string checkMD5(string filename)
        {   
            MD5 Md5 = MD5.Create();
            byte[] bytes;
            using (FileStream stream = File.OpenRead(filename))
            {   
                bytes = Md5.ComputeHash(stream);
                return BytesToString(bytes);
            }
        }

        public static string BytesToString(byte[] bytes)
        {
            string result = "";
            foreach (byte b in bytes) result += b.ToString("x2");
            return result;
        }
    }


}