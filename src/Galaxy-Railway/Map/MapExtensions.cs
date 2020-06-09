using System;
using System.Threading.Tasks;

namespace Galaxy_Railway
{
    public static class MapExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource @this,
          Func<TSource, TResult> fn) => fn(@this);

        public static async Task<TResult> MapAsync<TSource, TResult>(this TSource @this,
           Func<TSource, Task<TResult>> fn) => await fn(@this).ConfigureAwait(false);

        public static async Task<TResult> MapAsync<TSource, TResult>(this Task<TSource> @this,
          Func<TSource, TResult> fn) => fn(await @this.ConfigureAwait(false));

        public static async Task<TResult> MapAsync<TSource, TResult>(this Task<TSource> @this,
            Func<TSource, Task<TResult>> fn) => await fn(await @this.ConfigureAwait(false)).ConfigureAwait(false);
    }
}
