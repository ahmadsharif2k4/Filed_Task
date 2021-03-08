using System;

namespace Filed.Apis.RetryPattern
{
    public class RetryStrategy
    {
        private int MaxRetries { get; set; }

        private TimeSpan Interval { get; set; }

        public RetryStrategy(int maxRetries, TimeSpan interval)
        {
            this.MaxRetries = maxRetries;
            this.Interval = interval;
        }

        public int getMaxRetries()
        {
            return MaxRetries;
        }

        public TimeSpan getTimeInterval()
        {
            return Interval;
        }
    }
}
