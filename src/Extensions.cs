using System;

namespace RandomIdle
{
    public static class Extensions
    {
        public static T Offset<T>(this T value, int offset) where T : Enum
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] enumValues = (T[])Enum.GetValues(value.GetType());
            int j = (Array.IndexOf(enumValues, value) + offset) % enumValues.Length;
            if (j < 0) j = enumValues.Length + j;
            return enumValues[j];     
        }
    }
}
