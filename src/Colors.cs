using System.Diagnostics.Contracts;
using System.Numerics;
using ImGuiNET;

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
        public static readonly Vector4 LighterBlue = Util.RgbToVector4(77, 95);
        public static readonly Vector4 LightBlue = Util.RgbToVector4(48, 68);
        public static readonly Vector4 Blue = Util.RgbToVector4(18, 41);
        public static readonly Vector4 DarkBlue = Util.RgbToVector4(11, 26, 159);
        public static readonly Vector4 DarkerBlue = Util.RgbToVector4(7, 7, 15);

        public static readonly Vector4 Violet = Util.RgbToVector4(153, 128);
        public static readonly Vector4 Green = Util.RgbToVector4(30f, 221f, 48f);
        public static readonly Vector4 Yellow = Util.RgbToVector4(253, 246, 40);

        public static readonly Vector4 Dzhake = Util.RgbToVector4(59, 165, 92);




        public static void PushWaterColors() => PushTheme(Blue, LightBlue, LighterBlue);

        public static void PushNeutralColors() => PushTheme(DarkGrey, Grey, LightGrey);

        /// <summary>
        /// Pops same amount of colors as <see cref="PushColors"/> pushes.
        /// </summary>
        public static void PopColors()
        {
            ImGui.PopStyleColor(6);
        }

        /// <summary>
        /// Calls <see cref="PushColors"/> reusing colors, so you don't need to specify ALL of them.
        /// </summary>
        public static void PushTheme(Vector4 main, Vector4 hovered, Vector4 active) =>
            PushColors(main, hovered, active, main, hovered, active);

        /// <summary>
        /// Does <see cref="ImGui.PushStyleColor(ImGuiCol, Vector4)"/> for each color.
        /// </summary>
        public static void PushColors(Vector4 button, Vector4 buttonHovered, Vector4 buttonActive, Vector4 tab, Vector4 tabHovered,
            Vector4 tabActive)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, button);
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, buttonHovered);
            ImGui.PushStyleColor(ImGuiCol.ButtonActive, buttonActive);
            ImGui.PushStyleColor(ImGuiCol.Tab, tab);
            ImGui.PushStyleColor(ImGuiCol.TabHovered, tabHovered);
            ImGui.PushStyleColor(ImGuiCol.TabActive, tabActive);
        }


        private const string Hex = "0123456789ABCDEF";

        /// <summary>
        /// Parses hex string
        /// </summary>
        /// <param name="hex">Hex string to parse</param>
        [Pure]
        public static Vector4 ParseHex(string hex)
        {
            if (hex.StartsWith('#')) hex = hex[1..];
            hex = hex.ToUpper();
            float r = 1f;
            float g = 1f;
            float b = 1f;
            float a = 1f;

            switch (hex.Length)
            {
                case 3:
                case 4:
                    r = ParseHexSymbol(hex[0]) / 15f;
                    g = ParseHexSymbol(hex[1]) / 15f;
                    b = ParseHexSymbol(hex[2]) / 15f;
                    if (hex.Length == 4) a = ParseHexSymbol(hex[3]) / 16f;
                    break;
                case 6:
                case 8:
                    r = ParseHexSymbol(hex[0], hex[1]) / 255f;
                    g = ParseHexSymbol(hex[2], hex[3]) / 255f;
                    b = ParseHexSymbol(hex[4], hex[5]) / 255f;
                    if (hex.Length == 8) a = ParseHexSymbol(hex[6], hex[7]) / 255f;
                    break;
            }

            return new Vector4(r, g, b, a);
        }

        /// <summary>
        /// Returns value from 0 to 15 equal to passed symbol.
        /// </summary>
        /// <param name="symbol">Symbol to parse.</param>
        private static int ParseHexSymbol(char symbol) => Hex.IndexOf(symbol);

        private static float ParseHexSymbol(char symbol1, char symbol2)
        {
            return ParseHexSymbol(symbol1) * 16f + ParseHexSymbol(symbol2);
        }
    }
}
