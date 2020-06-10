namespace System
{
    public static class StringExtensions
    {
        public static bool IsNull(this string @this) => @this == null;
        public static bool IsNullOrEmpty(this string @this) => string.IsNullOrEmpty(@this); 
        public static bool IsNullOrWhiteSpace(this string @this) => string.IsNullOrWhiteSpace(@this);
    }
}
