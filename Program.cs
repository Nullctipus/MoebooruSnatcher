﻿using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoebooruSnatcher.Util;
using MoebooruSnatcher.JsonObjects;
using Newtonsoft.Json;

namespace MoebooruSnatcher
{
    static class Program
    {
        public static string booru = "yande.re";
        static List<string> tags = new List<string>();
        static string directory = "";
        static string replacestring = "_";
        static int pages = 0;
        static void Main(string[] args)
        {
            ConsoleUtils.LogLogoText();
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "-h":
                        ConsoleUtils.Log("-b: set booru\n-d: set directory\n-t: set tags\n-h: this info");
                        break;
                    case "-b":
                    case "-booru":
                        booru = args[i + 1];
                        break;
                    case "-f":
                    case "-file":
                    case "-d":
                    case "-dir":
                    case "-directory":
                        directory = args[i + 1];
                        break;
                    case "-tag":
                    case "-t":
                    case "-tags":
                        for (int j = i + 1; j < args.Length; j++)
                        {
                            tags.Add(args[j]);
                        }
                        break;
                    case "-page:":
                    case "-pages":
                    case "-p":
                        pages = int.Parse(args[i + 1]);
                        break;
                }
            }
            if(directory == "")
            {
                directory = Path.Combine(Environment.CurrentDirectory,booru,string.Join(" ",tags).Replace(":",replacestring));
            }
            foreach (char c in Path.GetInvalidPathChars())
            {
                directory = directory.Replace(c.ToString(), "");
            }
            ConsoleUtils.Debug(directory);
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            List<Piece> pieces = new List<Piece>();
            int i2 = 0;
            using (var webClient = new WebClient())
            {
                for (int i = 0; i < pages; i++)
                {
                    ConsoleUtils.Debug("https://" + booru + "/post.json?page=" + i + "&tags=" + string.Join("%20", tags));
                    string jsonpieces = new WebClient().DownloadString("https://" + booru + "/post.json?page=" + i + "&tags=" + string.Join("%20", tags));
                    
                    // = await HTTPRequest.get(booru + "/post.json?tags=" + tags + "&page="+i);
                    ConsoleUtils.Debug(jsonpieces);
                    pieces.AddRange(JsonConvert.DeserializeObject<List<Piece>>(jsonpieces));
                }

                foreach (Piece p in pieces)
                {
                    string name = p.file_url.Split('/').Last().Replace("%20", " ");
                    foreach (char c in Path.GetInvalidFileNameChars())
                    {
                        name = name.Replace(c.ToString(), "");
                    }
                    if(name.Length > 255)
                    {
                        name = name.Remove(251)+name.Substring(name.Length-4);
                    }
                    byte[] data = webClient.DownloadData(p.file_url);
                    try
                    {
                        File.WriteAllBytes(Path.Combine(directory, name), data);
                    }
                    catch
                    {
                        File.WriteAllBytes(Path.Combine(directory, i2 + name.Substring(name.Length - 4)), data);
                        i2++;
                    }
                    ConsoleUtils.Success("Downloaded " + name);
                }
            }
        }
    }
}
