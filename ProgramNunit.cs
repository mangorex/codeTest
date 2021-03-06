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

        [Test]
        public void TestDownloadSerializedJsonP6BasicCount()
        {
            var url = "http://127.0.0.1/assetsTree.json";
            var root = Program.downloadSerializedJson<Root>(url); 
            Assert.AreEqual(3, root.p6.Count);
        }


        [Test]
        public void TestDownloadSerializedJsonP6Basic()
        {
            var url = "http://127.0.0.1/assetsTree.json";
            var root = Program.downloadSerializedJson<Root>(url); 
            Console.WriteLine(root.p6.Count.ToString());
            Assert.AreEqual(true, root.p6[2].required);
        }
    }
}
