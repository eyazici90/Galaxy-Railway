using System; 
using System.Threading;
using System.Threading.Tasks;

namespace Galaxy_Railway.Threading
{
    public static class LockExtensions
    {
        public static async Task LockAsync(this SemaphoreSlim @semaphore, Func<Task> task)
        {
            await @semaphore.WaitAsync().ConfigureAwaitFalse();
            try
            {
                await task().ConfigureAwaitFalse();
            }
            finally
            {
                @semaphore.Release();
            }
        }

        public static void Lock(this SemaphoreSlim @semaphore, Action action)
        {
            @semaphore.Wait();
            try
            {
                action();
            }
            finally
            {
                @semaphore.Release();
            }
        }

        public static void Lock(this object source, Action action)
        {
            lock (source)
            {
                action();
            }
        }
        public static void Lock<T>(this T source, Action<T> action) where T : class
        {
            lock (source)
            {
                action(source);
            }
        }
        public static TResult Lock<TResult>(this object source, Func<TResult> func)
        {
            lock (source)
            {
                return func();
            }
        }

        public static TResult Lock<T, TResult>(this T source, Func<T, TResult> func) where T : class
        {
            lock (source)
            {
                return func(source);
            }
        }
    }
}
