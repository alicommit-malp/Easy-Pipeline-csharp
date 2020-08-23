using System.Threading.Tasks;

namespace EasyPipeLine
{
    public abstract class WorkStation
    {
        public abstract Task InvokeAsync(IPipelineData data);
    }
}