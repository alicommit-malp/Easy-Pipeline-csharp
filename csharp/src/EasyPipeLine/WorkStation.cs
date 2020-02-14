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

        public async Task Run(IPipelineData data)
        {
            if(IsRoot)
               await InvokeAsync(data);
            else
            {
                _prevWorkStation?.Run(data);
            }
        }

        protected virtual async Task InvokeAsync(IPipelineData data)
        {
            if (_nextWorkStation != null) await _nextWorkStation?.InvokeAsync(data);
        }
    }
}