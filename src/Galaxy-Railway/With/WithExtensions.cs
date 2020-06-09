using System;
using System.Threading.Tasks;

namespace Galaxy_Railway.With
{
    public static class WithExtensions
    {
        public static T With<T>(this T @obj, Action<T> update)
        {
            update(@obj);
            return @obj;
        }

        public static async Task<T> WithAsync<T>(this T @obj, Func<T, Task> update)
        {
            await update(@obj).ConfigureAwait(false);
            return @obj;
        }

        public static async Task<T> WithAsync<T>(this Task<T> @task, Func<T, Task> update)
        {
            var result = await @task.ConfigureAwait(false);

            await update(result).ConfigureAwait(false);

            return result;
        }

        public static async Task<T> WithAsync<T>(this Task<T> @task, Action<T> update)
        {
            var result = await @task.ConfigureAwait(false);

            update(result);

            return result;
        }
    }
}
