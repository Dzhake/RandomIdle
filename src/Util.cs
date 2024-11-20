using System.Numerics;

namespace RandomIdle
{
    public static class Util
    {
        /// <summary>
        /// Takes values between 0 and 255 and returns <see cref="Vector4"/> with values between 0 and 1
        /// </summary>
        /// <param name="r">Red value</param>
        /// <param name="g">Green value</param>
        /// <param name="b">Blue value</param>
        /// <param name="a">Alpha value</param>
        /// <returns><see cref="Vector4"/> with values between 0 and 1</returns>
        public static Vector4 RgbToVector4(float r = 255, float g = 255, float b = 255, float a = 255)
        {
            return new Vector4(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}
