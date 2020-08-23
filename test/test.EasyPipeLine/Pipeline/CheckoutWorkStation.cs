using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Pipeline
{
    public class CheckoutWorkStation : WorkStation
    {
        public override Task InvokeAsync(IPipelineData data)
        {
            Test.Logger.LogTrace(nameof(CheckoutWorkStation));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(CheckoutWorkStation);
            
            Test.Logger.LogInformation($"State:{nameof(CheckoutWorkStation)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");

            return Task.CompletedTask;
        }
    }
}