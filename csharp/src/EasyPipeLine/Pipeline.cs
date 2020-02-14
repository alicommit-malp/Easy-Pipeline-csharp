using System.Threading.Tasks;
using EasyPipeLine.deprecated;

namespace EasyPipeLine
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Pipeline :WorkStation
    {
        public Pipeline()
        {
            IsRoot = true;
        }

        protected override async Task InvokeAsync(IPipelineData data)
        {
            await base.InvokeAsync(data);
        }
    }
}