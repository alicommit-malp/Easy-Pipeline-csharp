using EasyPipeLine;

namespace test.EasyPipeLine.Pipeline
{
    public class OrderData : IPipelineData
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}