﻿using System;
using System.Threading.Tasks;

namespace Galaxy.Railway
{
    public static class AndThenExtensions
    {
        public static TResult AndThen<T, TResult>(this T @this, Func<T, TResult> func) => func(@this);

        public static T AndThen<T>(this T @this, Action<T> action)
        {
            action(@this);
            return @this;
        }
        public static async Task<TResult> AndThenAsync<T, TResult>(this T @this,
        Func<T, Task<TResult>> func) =>
        await func(@this).ConfigureAwait(false);

        public static async Task AndThenAsync<T>(this T @this,
        Func<T, Task> func) =>
        await func(@this).ConfigureAwait(false);

        public static async Task AndThenAsync<T>(this Task<T> @this,
           Action<T> action) =>
            action(await @this.ConfigureAwait(false));

        public static async Task<TResult> AndThenAsync<T, TResult>(this Task<T> @this,
           Func<T, Task<TResult>> func) =>
           await func((await @this.ConfigureAwait(false))).ConfigureAwait(false);

        public static async Task<TResult> AndThenAsync<T, TResult>(this Task<T> @this,
            Func<T, TResult> func) =>
            func((await @this.ConfigureAwait(false)));
    }
}
