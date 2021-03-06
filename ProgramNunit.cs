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
        public void Test_download_serialized_json_data_Count()
        {
            var url = "http://127.0.0.1/assetsTree.json";
            var root = Program._download_serialized_json_data<Root>(url); 
            Assert.AreEqual(3, root.p6.Count);
        }


        [Test]
        public void Test_download_serialized_json_data_required()
        {
            var url = "http://127.0.0.1/assetsTree.json";
            var root = Program._download_serialized_json_data<Root>(url); 
            Console.WriteLine(root.p6.Count.ToString());
            Assert.AreEqual(true, root.p6[2].required);
        }
    }
}
