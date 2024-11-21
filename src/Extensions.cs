using System;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace RandomIdle
{
    public static class Extensions
    {
        /// <summary>
        /// Returns 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [Pure]
        public static T Offset<T>(this T value, int offset) where T : Enum
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] enumValues = (T[])Enum.GetValues(value.GetType());
            int j = (Array.IndexOf(enumValues, value) + offset) % enumValues.Length;
            if (j < 0) j = enumValues.Length + j;
            return enumValues[j];     
        }

        /// <summary>
        /// Returns vector's values as string in format "{X}x{Y}", useful for short <see cref="ToStringX"/> or to display window size/resolution.
        /// </summary>
        /// <param name="vector">Vector which should be converted to string</param>
        [Pure]
        public static string ToStringX(this Vector2 vector) => $"{vector.X}x{vector.Y}";
    }
}
