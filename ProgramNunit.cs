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
            var url = "http://127.0.0.1/latest.json";
            var currencyRates = Program._download_serialized_json_data<CurrencyRates>(url);

            Assert.AreEqual("This data is collected from various providers ...", currencyRates.Disclaimer);
        }
    }
}
