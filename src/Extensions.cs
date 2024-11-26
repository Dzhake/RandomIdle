using System;
using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework;
using Vector2 = System.Numerics.Vector2;

namespace RandomIdle
{
    public static class Extensions
    {
        /// <summary>
        /// Returns value in enum, offsetted by specific amount (by enum values, not by value's value)
        /// </summary>
        /// <typeparam name="T">Enum with values</typeparam>
        /// <param name="value">Value to offset</param>
        /// <param name="offset">Offset amount</param>
        /// <returns>Offsetted value</returns>
        /// <remarks>Works with int enums only!</remarks>
        /// <exception cref="ArgumentException">Thrown when <see cref="T"/> is not an enum</exception>
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
        /// Returns vector's values as string in format "{X}x{Y}", useful as short <see cref="Vector2.ToString()"/>.
        /// </summary>
        /// <param name="vector">Vector to convert</param>
        [Pure]
        public static string ToStringX(this Vector2 vector) => $"{vector.X}x{vector.Y}";

        /// <summary>
        /// Converts <see cref="Vector2"/> to <see cref="Point"/>, cutting numbers after floating point
        /// </summary>
        /// <param name="vector">Vector to convert</param>
        [Pure]
        public static Point ToPoint(this Vector2 vector) => new((int)vector.X, (int)vector.Y);
    }
}
