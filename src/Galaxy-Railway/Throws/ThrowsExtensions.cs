using System;
using System.Threading.Tasks;

namespace Galaxy_Railway.Throws
{
    public static class ThrowsExtensions
    {
        public static async Task<T> ThrowsIfAsync<T>(this T @obj, Func<T, Task<bool>> assert, Exception exception)
        {
            var sut = await assert(@obj).ConfigureAwait(false);

            if (sut)
                throw exception;

            return @obj;
        }

        public static T ThrowsIfNull<T>(this T @obj, Exception exception)
        {
            if (@obj == null)
                throw exception;

            return @obj;
        }

        public static T ThrowsIf<T>(this T @obj, Func<T, bool> assert, Exception exception)
        {
            var sut = assert(@obj);

            if (sut)
                throw exception;

            return @obj;
        }


        public static T ThrowsIf<T>(this T @obj, Func<T, bool> assert, Action<T> throwing)
        {
            var sut = assert(@obj);

            if (sut)
                throwing(@obj);

            return @obj;
        }

        public static async Task<T> ThrowsIfAsync<T>(this T @obj, Func<T, Task<bool>> assert, Func<T, Task> throwing)
        {
            var sut = await assert(@obj).ConfigureAwait(false);

            if (sut)
                await throwing(@obj).ConfigureAwait(false);

            return @obj;
        }

        public static async Task<T> ThrowsIfAsync<T, TException>(this Task<T> @task,
           Func<T, bool> assertion,
           TException exception) where TException : Exception
        {
            var result = await @task.ConfigureAwait(false);

            if (assertion(result))
                throw exception;

            return result;
        }

    }
}
