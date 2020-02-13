using EasyPipeLine;
using EasyPipeLine.deprecated;

namespace test.EasyPipeLine.Handlers
{
    public class OrderData : ILinkData
    {
        public string Name { get; set; }
        public string State { get; set; }
    }
}