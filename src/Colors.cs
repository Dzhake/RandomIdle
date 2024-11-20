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
    }
}
