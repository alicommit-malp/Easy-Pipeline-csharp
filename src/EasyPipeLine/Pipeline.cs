using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyRetry;

namespace EasyPipeLine
{
    public class Pipeline
    {
        private readonly Queue<WorkStation> _workStations = new Queue<WorkStation>();

        /// <summary>
        /// Adding easily the <see cref="WorkStation"/> to the pipeline
        /// </summary>
        /// <param name="workStation">A step in the pipeline which must inherit from the <see cref="WorkStation"/> class</param>
        /// <returns>This <see cref="Pipeline"/> to provide the builder pattern feature</returns>
        public Pipeline Next(WorkStation workStation)
        {
            _workStations.Enqueue(workStation);
            return this;
        }

        /// <summary>
        /// Run all the <see cref="WorkStation"/> in the order the have been added
        /// </summary>
        /// <param name="pipelineData">The data which will be passed between all the <see cref="WorkStation"/> <seealso cref="IPipelineData"/></param>
        /// <param name="retryOptions"></param>
        /// <returns>A task which will be responsible for the whole execution of the pipeline</returns>
        /// <exception cref="EasyPipelineException"></exception>
        public async Task Run(IPipelineData pipelineData)
        {
            while (_workStations.TryDequeue(out var workStation))
            {
                try
                {
                    var retryAttribute =
                        (AutoRetryAttribute) Attribute.GetCustomAttribute(workStation.GetType(),typeof (AutoRetryAttribute));

                    //retry if demanded
                    if (retryAttribute != null)
                        await workStation.InvokeAsync(pipelineData).Retry(new RetryOptions()
                        {
                            Attempts = retryAttribute.Attempts,
                            DelayBetweenRetries = TimeSpan.FromSeconds(retryAttribute.DelaySeconds),
                        });
                    else
                        await workStation.InvokeAsync(pipelineData);
                }
                catch (Exception e)
                {
                    throw new EasyPipelineException(
                        $"Pipeline has failed to continue please check inner exception for more details", e);
                }
            }
        }
    }
}