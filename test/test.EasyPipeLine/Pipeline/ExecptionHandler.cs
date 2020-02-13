using System;
using System.Threading.Tasks;
using EasyPipeLine;
using Microsoft.Extensions.Logging;

namespace test.EasyPipeLine.Handlers
{
    public class ExceptionLink : WorkStation
    {
        protected override async Task InvokeAsync(IPipelineData data)
        {
            Test.Logger.LogTrace(nameof(ExceptionLink));
            try
            {
                await base.InvokeAsync(data);
            }
            catch (Exception e)
            {
                Test.Logger.LogError(e.Message);
                //handle the exception here 
            }
        }
    }
}