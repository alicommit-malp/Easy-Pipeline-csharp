using System;

namespace EasyPipeLine
{
    [AttributeUsage(AttributeTargets.Method)]  
    public class AutoRetryAttribute :Attribute
    {
        public int DelaySeconds { get;}
        public int Attempts { get;  }
        public int DelayBeforeFirstTry { get; }
        
        public AutoRetryAttribute(int attempts)
        {
            DelaySeconds = 5;
            Attempts = attempts;
            DelayBeforeFirstTry = 0;
        }
        public AutoRetryAttribute(int delaySeconds,int attempts)
        {
            DelaySeconds = delaySeconds;
            Attempts = attempts;
            DelayBeforeFirstTry = 0;
        }
        public AutoRetryAttribute(int delaySeconds,int attempts, int delayBeforeFirstTry)
        {
            DelaySeconds = delaySeconds;
            Attempts = attempts;
            DelayBeforeFirstTry = delayBeforeFirstTry;
        }
    }
}