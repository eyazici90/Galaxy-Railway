using System.Threading.Tasks;

namespace Galaxy_Railway
{
    public static class OptionalExtensions
    {
        public static Optional<T> ToOptional<T>(this T @this) =>
            new Optional<T>(@this);

        public static async Task<Optional<T>> ToOptionalAsync<T>(this Task<T> @this) =>
            new Optional<T>(await @this.ConfigureAwait(false));

        public static Optional<T> ToEmptyOptional<T>(this T _) =>
            Optional<T>.Empty;

    }
}
