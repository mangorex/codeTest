using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using NUnit.Framework;
using codeTest;

namespace UnitTesting.GettingStarted.Tests
{
    [TestFixture]
    public class ProgramNunit
    {
        static string url = "http://127.0.0.1/";
        static string route = "/home/manu/codeGR/";
        static Root root = Program.downloadSerializedJson<Root>(url);

        [Test]
        public void TestP6BasicCount()
        {
            Assert.AreEqual(3, root.p6.Count);
        }

        [Test]
        public void TestP6BasicRequired()
        {
            Console.WriteLine(root.p6.Count.ToString());
            Assert.AreEqual(true, root.p6[2].required);
        }

        [Test]
        public void TestLoopCommonListBasic()
        {
            List<Common> Lcommon = root.common;
            bool ok = Program.loopCommonList(Lcommon);
            Console.WriteLine(Lcommon.Count.ToString());
            Assert.AreEqual(true, ok);
        }

        [Test]
        public void TestLoopFgBasic()
        {
            List<Fg> Lfg = root.fg;
            bool ok = Program.loopFg(Lfg);
            Console.WriteLine(Lfg.Count.ToString());
            Assert.AreEqual(true, ok);
        }

        [Test]
        public void TestLoopP6Basic()
        {
            List<P6> Lp6 = root.p6;
            bool ok = Program.loopP6(Lp6);
            Console.WriteLine(Lp6.Count.ToString());
            Assert.AreEqual(true, ok);
        }

        [Test]
        public void TestLoopLangBasic()
        {
            List<Lang> Llang = root.p6[1].lang;
            bool ok = Program.loopLang(Llang);
            Console.WriteLine(Llang.Count.ToString());
            Assert.AreEqual(true, ok);
        }

        [Test]
        public void TestDownloadAFileNoAsync()
        {
            Assert.AreEqual(true, Program.downloadAFileNoAsync());
        }
    }
}
