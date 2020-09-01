using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace velocityraptor.Tests.Integration
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Program.CreateHostBuilder(new[] {"%LAUNCHER_ARGS%" } ).Build().Run();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}