using System;
using System.Globalization;

namespace Galaxy.Railway
{
    public static class CastExtensions
    {
        public static T As<T>(this object @this)
              where T : class =>
             (T)@this;


        public static T To<T>(this object @this)
            where T : struct =>
            (T)Convert.ChangeType(@this, typeof(T), CultureInfo.InvariantCulture);

    }
}
