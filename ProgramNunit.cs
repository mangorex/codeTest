using NUnit.Framework;

namespace UnitTesting.GettingStarted.Tests
{
     [TestFixture]
      public class ProgramNunit
      {
          [Test]
          public void TestProgramNunit()
          {
              Assert.That(true, Is.False);
          }
      }
}
