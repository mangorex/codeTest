    using System.Collections.Generic;

    public class Common
    {
        public bool required { get; set; }
        public string name { get; set; }
        public string md5 { get; set; }
    }

    public class P6
    {
        public List<Common> common { get; set; }
    }

    public class Root
    {
        public List<P6> p6 { get; set; }
    }
