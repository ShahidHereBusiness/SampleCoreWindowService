using System.Diagnostics;

namespace NUTP
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCase()
        {
            Console.WriteLine(SOA.MakeDeminish.LogEvent("Hello Windows Event Viewer Log"));
            //Assert.Pass();
        }
    }
}