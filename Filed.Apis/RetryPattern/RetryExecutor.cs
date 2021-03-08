using System;
using System.Threading.Tasks;

namespace Filed.Apis.RetryPattern
{
    public class RetryExecutor
    {
        public readonly RetryStrategy _retryStrategy;

        public RetryExecutor(RetryStrategy retryStrategy)
        {
            this._retryStrategy = retryStrategy;
        }
        public bool Retry(Action logic) 
        {
            int retries = 0;
            int maxRetries = _retryStrategy.getMaxRetries();
            TimeSpan interval = _retryStrategy.getTimeInterval();

            while (true)
            {
                try
                {
                    retries++;
                    logic();
                    return true;
                }
                catch (Exception ex)
                {
                    //log the exception 
                    if (retries == maxRetries)
                    {
                        return false;
                    }
                    else 
                    {
                        Task.Delay(interval).Wait();
                    }
                }
            }
        }
    }
}
