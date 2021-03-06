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
        public void TestProgramNunit()
        {
            Assert.That(true, Is.True);
        }

        [Test]
        public void Test_download_serialized_json_data()
        {
            var url = "http://127.0.0.1/codetest.json";
            var root = Program._download_serialized_json_data<Root>(url); 
            Assert.AreEqual(true, root.p6[0].common[0].required);
        }
    }
}
