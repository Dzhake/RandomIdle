using System.Numerics;

namespace RandomIdle
{
    /// <summary>
    /// Contains colors for using in ImGui methods
    /// </summary>
    public static class Colors
    {
        //white to black
        public static readonly Vector4 White = Util.RgbToVector4();
        public static readonly Vector4 LighterGrey = new(0.85f, 0.85f, 0.85f, 1f);
        public static readonly Vector4 LightGrey = new(0.7f, 0.7f, 0.7f, 1f);
        public static readonly Vector4 Grey = new(0.5f, 0.5f, 0.5f, 1f);
        public static readonly Vector4 DarkGrey = new(0.3f, 0.3f, 0.3f, 1f);
        public static readonly Vector4 DarkerGrey = new(0.1f, 0.1f, 0.1f, 1f);
        public static readonly Vector4 Black = new(0f, 0f, 0f, 1f);

        //blue tones
        public static readonly Vector4 LigherBlue = Util.RgbToVector4(77, 95);
        public static readonly Vector4 LightBlue = Util.RgbToVector4(48, 68);
        public static readonly Vector4 Blue = Util.RgbToVector4(18, 41);
        public static readonly Vector4 DarkBlue = Util.RgbToVector4(11, 26, 159);
        public static readonly Vector4 DarkerBlue = Util.RgbToVector4(7, 7, 15);

        public static readonly Vector4 Violet = Util.RgbToVector4(153, 128);
        public static readonly Vector4 Green = Util.RgbToVector4(30f, 221f, 48f);
        public static readonly Vector4 Yellow = Util.RgbToVector4(253, 246, 40);
    }
}
