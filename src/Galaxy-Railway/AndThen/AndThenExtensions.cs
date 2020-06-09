using System;
using System.Threading.Tasks;

namespace Galaxy_Railway.AndThen
{
    public static class AndThenExtensions
    {
        public static TResult AndThen<T, TResult>(this T @obj, Func<T, TResult> func) => func(@obj);

        public static T AndThen<T>(this T @obj, Action<T> func)
        {
            func(@obj);
            return @obj;
        }

        public static async Task<TResult> AndThenAsync<T, TResult>(this Task<T> @task,
           Func<T, Task<TResult>> func) =>
           await func((await task.ConfigureAwait(false))).ConfigureAwait(false);

        public static async Task<TResult> AndThenAsync<T, TResult>(this Task<T> @task,
            Func<T, TResult> func) =>
            func((await task.ConfigureAwait(false)));
    }
}
