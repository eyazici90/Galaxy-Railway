using System;
using System.Threading.Tasks;

namespace Galaxy.Railway
{
    public static class ThrowsExtensions
    {
        public static async Task<T> ThrowsIfAsync<T>(this T @this, Func<T, Task<bool>> assert, Exception exception)
        {
            var sut = await assert(@this).ConfigureAwait(false);

            if (sut)
                throw exception;

            return @this;
        }

        public static T ThrowsIfNull<T>(this T @this, Exception exception)
        {
            if (@this == null)
                throw exception;

            return @this;
        }

        public static T ThrowsIf<T>(this T @this, Func<T, bool> assert, Exception exception)
        {
            var sut = assert(@this);

            if (sut)
                throw exception;

            return @this;
        }


        public static T ThrowsIf<T>(this T @this, Func<T, bool> assert, Action<T> throwing)
        {
            var sut = assert(@this);

            if (sut)
                throwing(@this);

            return @this;
        }

        public static async Task<T> ThrowsIfAsync<T>(this T @this, Func<T, Task<bool>> assert, Func<T, Task> throwing)
        {
            var sut = await assert(@this).ConfigureAwait(false);

            if (sut)
                await throwing(@this).ConfigureAwait(false);

            return @this;
        }

        public static async Task<T> ThrowsIfAsync<T, TException>(this Task<T> @this,
           Func<T, bool> assertion,
           TException exception) where TException : Exception
        {
            var result = await @this.ConfigureAwait(false);

            if (assertion(result))
                throw exception;

            return result;
        }

    }
}
