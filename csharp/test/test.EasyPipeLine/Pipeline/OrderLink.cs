using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Pipeline
{
    public class OrderLink : WorkStation
    {
        protected override async Task InvokeAsync(IPipelineData data)
        {
            Test.Logger.LogTrace(nameof(OrderLink));

            if (!(data is OrderData order)) throw new ArgumentNullException();

            order.State = nameof(OrderLink);

            Test.Logger.LogInformation($"State:{nameof(OrderLink)} objectState: " +
                                       $"{JsonConvert.SerializeObject(order)}");
            await base.InvokeAsync(order);
        }
    }
}