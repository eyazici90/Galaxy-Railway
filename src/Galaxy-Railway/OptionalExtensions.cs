namespace Galaxy_Railway
{
    public static class OptionalExtensions
    {
        public static Optional<T> ToOptional<T>(this T @obj) =>
            new Optional<T>(@obj);

        public static Optional<T> ToEmptyOptional<T>(this T _) =>
            Optional<T>.Empty;

    }
}
