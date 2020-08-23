using System.Threading.Tasks;

namespace EasyPipeLine
{
    public abstract class WorkStation
    {
        private WorkStation _nextWorkStation;
        private WorkStation _prevWorkStation;
        protected bool IsRoot;

        public WorkStation Next(WorkStation workStation)
        {
            _nextWorkStation = workStation;
            _nextWorkStation._prevWorkStation = this;
            return _nextWorkStation;
        }

        public Task Run(IPipelineData data)
        {
            if (IsRoot) return InvokeAsync(data);
            _prevWorkStation?.Run(data);
            return Task.CompletedTask;
        }

        protected virtual  Task InvokeAsync(IPipelineData data)
        {
            return _nextWorkStation != null ? _nextWorkStation?.InvokeAsync(data) : Task.CompletedTask;
        }
    }
}