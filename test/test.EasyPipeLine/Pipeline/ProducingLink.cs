using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Pipeline
{
    public class ProducingLink : WorkStation
    {
        protected override async Task InvokeAsync(IPipelineData data)
        {
           Test.Logger .LogTrace(nameof(ProducingLink));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(ProducingLink);
            
            Test.Logger.LogInformation($"State:{nameof(ProducingLink)} objectState: " +
                              $"{JsonConvert.SerializeObject(order)}");
            await base.InvokeAsync(order);
        }
        
    }
}