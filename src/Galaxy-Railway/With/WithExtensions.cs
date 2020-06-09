using System;
using System.Threading.Tasks;

namespace Galaxy_Railway.With
{
    public static class WithExtensions
    {
        public static T With<T>(this T @this, Action<T> update)
        {
            update(@this);
            return @this;
        }

        public static async Task<T> WithAsync<T>(this T @this, Func<T, Task> update)
        {
            await update(@this).ConfigureAwait(false);
            return @this;
        }

        public static async Task<T> WithAsync<T>(this Task<T> @this, Func<T, Task> update)
        {
            var result = await @this.ConfigureAwait(false);

            await update(result).ConfigureAwait(false);

            return result;
        }

        public static async Task<T> WithAsync<T>(this Task<T> @this, Action<T> update)
        {
            var result = await @this.ConfigureAwait(false);

            update(result);

            return result;
        }
    }
}
