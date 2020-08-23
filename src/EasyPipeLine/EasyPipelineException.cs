#nullable enable
using System;
using System.Runtime.Serialization;

namespace EasyPipeLine
{
    public class EasyPipelineException : Exception
    {
        public EasyPipelineException()
        {
        }

        protected EasyPipelineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EasyPipelineException(string? message) : base(message)
        {
        }

        public EasyPipelineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}