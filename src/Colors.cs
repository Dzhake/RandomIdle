using System.Numerics;

namespace RandomIdle
{
    /// <summary>
    /// Contains colors for using in ImGui methods
    /// </summary>
    public static class Colors
    {
        public static readonly Vector4 White = Util.RgbToVector4();
        public static readonly Vector4 Black = Util.RgbToVector4(0,0,0);
        public static readonly Vector4 Green = Util.RgbToVector4(30f, 221f, 48f);
        public static readonly Vector4 Yellow = Util.RgbToVector4(253, 246, 40);

        public static readonly Vector4 Blue = Util.RgbToVector4(18, 41);
        public static readonly Vector4 LightBlue = Util.RgbToVector4(48, 68);
        public static readonly Vector4 LigherBlue = Util.RgbToVector4(77, 95);


        public static readonly Vector4 Violet = Util.RgbToVector4(153, 128);
    }
}
