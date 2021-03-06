    using System.Collections.Generic;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class EnGB
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Help
    {
        public List<EnGB> en_GB { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Language
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class PtfTerminal
    {
        public List<object> skins { get; set; }
        public List<Help> help { get; set; }
        public List<Language> languages { get; set; }
    }

    public class Common
    {
        public List<PtfTerminal> ptf_Terminal { get; set; }
        public List<Src> src { get; set; }
        public List<Explosion> explosion { get; set; }
        public List<Efecto> efectos { get; set; }
        public List<Musica> musica { get; set; }
        public List<Intro> intro { get; set; }
        public List<GamePanel> gamePanel { get; set; }
    }

    public class Fizzbuzz
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class CampoDeMina
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Math
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Leapyear
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Lcd
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class StringCalculator
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Statistic
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Fecha
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Src
    {
        public List<Fizzbuzz> fizzbuzz { get; set; }
        public List<CampoDeMina> campoDeMinas { get; set; }
        public List<Math> math { get; set; }
        public List<Leapyear> leapyear { get; set; }
        public List<Lcd> lcd { get; set; }
        public List<StringCalculator> stringCalculator { get; set; }
        public List<Statistic> statistics { get; set; }
        public List<Fecha> fechas { get; set; }
    }

    public class Fg
    {
        public List<object> skins { get; set; }
        public List<Common> common { get; set; }
    }

    public class Explosion
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Bola
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Vario
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Efecto
    {
        public List<Bola> bola { get; set; }
        public List<Vario> varios { get; set; }
    }

    public class MainGame
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class MainGameResult
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class MainGamePaytable
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Musica
    {
        public List<MainGame> main_game { get; set; }
        public List<MainGameResult> main_game_results { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
        public List<MainGamePaytable> main_game_paytable { get; set; }
    }

    public class Intro
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class GamePanel
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class En
    {
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Lang
    {
        public List<En> en { get; set; }
    }

    public class P6
    {
        public List<Common> common { get; set; }
        public List<Lang> lang { get; set; }
        public string md5 { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
    }

    public class Root
    {
        public List<Common> common { get; set; }
        public List<Fg> fg { get; set; }
        public List<P6> p6 { get; set; }
    }

