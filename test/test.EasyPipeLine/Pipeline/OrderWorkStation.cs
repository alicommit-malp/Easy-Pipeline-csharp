using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Pipeline
{
    public class OrderWorkStation : WorkStation
    {
        public override Task InvokeAsync(IPipelineData data)
        {
            Test.Logger.LogTrace(nameof(OrderWorkStation));

            if (!(data is OrderData order)) throw new ArgumentNullException();

            
            order.State = nameof(OrderWorkStation);

            Test.Logger.LogInformation($"State:{nameof(OrderWorkStation)} objectState: " +
                                       $"{JsonConvert.SerializeObject(order)}");
            
            return Task.CompletedTask;
        }
    }
}