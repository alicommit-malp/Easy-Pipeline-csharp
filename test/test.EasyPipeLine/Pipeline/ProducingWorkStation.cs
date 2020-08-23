using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace test.EasyPipeLine.Pipeline
{
    public class ProducingWorkStation : WorkStation
    {
        protected override Task InvokeAsync(IPipelineData data)
        {
           Test.Logger .LogTrace(nameof(ProducingWorkStation));
            
            if(!(data is OrderData order)) throw new ArgumentNullException();
            order.State = nameof(ProducingWorkStation);
            
            Test.Logger.LogInformation(message: $"State:{nameof(ProducingWorkStation)} objectState: " +
                                                $"{ JsonConvert.SerializeObject(order)}");
            
            // throw new Exception("random");
            return base.InvokeAsync(order);
        }
        
    }
}