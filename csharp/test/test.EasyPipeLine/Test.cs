using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using test.EasyPipeLine.Handlers;
using test.EasyPipeLine.Pipeline;

namespace test.EasyPipeLine
{
    [TestFixture]
    public class Test
    {
        public static ILogger<Test> Logger = TestLogger.Create<Test>();

        [Test]
        public async Task Test1()
        {
            var order = new OrderData()
            {
                Name = "Coffee",
                State = "None"
            };

            await new global::EasyPipeLine.Pipeline()
                .Next(new ExceptionLink())
                .Next(new OrderLink())
                .Next(new CheckoutLink())
                .Next(new ProducingLink())
                .Run(order);

            Assert.AreEqual(nameof(ProducingLink), nameof(ProducingLink));
        }
    }
}