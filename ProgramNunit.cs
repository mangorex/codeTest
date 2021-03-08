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
        public void TestDownloadSerializedJson()
        {
            bool error = false;
            string [] args = {
                "http://127.0.0.1/", 
                "assetsSimple.json",
                 "/home/manu/codeGR/files/"
                 };
            try{
                Program.Main(args);
            } catch (Exception)
            {
                error = true;
            }
            
            Assert.AreEqual(false, error);
        }

        // I think that the interaction between Main and DownloadAFileAsync must be done wit Moq, but I do not have time

        // This test does not works because in the code I use arguments for url, 
        // filejson and path to download
        /*[Test]
        public void TestDownloadAFileAsync()
        {
            DownloadOBJ downObj = new DownloadOBJ (
                true, "common/explosion", "ball_explodes_generic_00022.png", "cd986a8875c498f78ea61b8f3de57338"
            );
            
            Assert.AreEqual(true, Program.downloadAFileAsync(downObj));
        }*/
    
    
        [Test]
        public void TestCheckEqualMd5()
        {
            string expectedMd5 = "4dc16fe794705ae3d10927787d981e9a";
            string filePathName = "/home/manu/explosion.png";
            Assert.AreEqual(expectedMd5, Program.checkMD5(filePathName));
        }
    }
}
