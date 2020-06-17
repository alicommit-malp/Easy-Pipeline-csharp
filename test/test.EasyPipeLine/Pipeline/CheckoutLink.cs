using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using test.EasyPipeLine.Handlers;

namespace test.EasyPipeLine.Pipeline
{
    public class CheckoutLink : WorkStation
    {
        protected override async Task InvokeAsync(IPipelineData data)
        {
            Test.Logger.LogTrace(nameof(CheckoutLink));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(CheckoutLink);
            
            Test.Logger.LogInformation($"State:{nameof(CheckoutLink)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            await base.InvokeAsync(order);
        }
    }
}