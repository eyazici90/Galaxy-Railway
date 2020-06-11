using System;
using System.Threading.Tasks;

namespace Galaxy.Railway
{
    public static class IfExtensions
    {
        public static T If<T>(this T @this, bool condition, Func<T, T> func)
        {
            if (condition)
                return func(@this);

            return @this;
        }

        public static T If<T>(this T @this, bool condition, Action<T> action)
        {
            if (condition)
                action(@this);

            return @this;
        }

        public static async Task<T> IfAsync<T>(this T @this, bool condition, Func<T, Task> func)
        {
            if (condition)
                await func(@this).ConfigureAwait(false);

            return @this;
        }

        public static async Task<T> IfAsync<T>(this Task<T> @this, bool condition, Func<T, Task> func)
        {
            var result = await @this.ConfigureAwait(false);

            if (condition)
                await func(result).ConfigureAwait(false);

            return result;
        }

        public static async Task<T> IfAsync<T>(this Task<T> @this, bool condition, Action<T> action)
        {
            var result = await @this.ConfigureAwait(false);

            if (condition)
                action(result);

            return result;
        }
    }
}
