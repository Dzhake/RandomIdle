using System;
using System.Drawing;
using System.Numerics;
using ImGuiNET;

namespace RandomIdle;

public static class AdvancedText
{
    /// <summary>
    /// Draws text with advanced features:
    /// {#XXXXXX} - set text color
    /// {#} - reset text's color
    /// </summary>
    /// <param name="text">Text to draw.</param>
    public static void Draw(string text)
    {
        int i = 0;
        string subtext = "";
        Vector4 currentColor = Vector4.One;
        bool inBracket = false;
        bool drew = false;

        while (i < text.Length)
        {
            char symbol = text[i];
            bool addSymbol = true;
            switch (symbol)
            {
                case '{':
                {
                    if (drew) ImGui.SameLine(0, 0);

                    else if (currentColor == Vector4.One)
                        ImGui.Text(subtext);
                    else
                        ImGui.TextColored(currentColor, subtext);
                    drew = true;
                    subtext = "";
                    inBracket = true;
                    addSymbol = false;
                    break;
                }
                case '}':
                    if (!inBracket) throw new ArgumentException("Bracket was closed without opening!", nameof(text));

                    if (subtext == "#")
                        currentColor = Vector4.One;
                    else if (subtext.StartsWith('#'))
                        currentColor = Colors.ParseHex(subtext);

                    subtext = "";
                    addSymbol = false;
                    break;
            }

            if (addSymbol) subtext += symbol;
            i++;
        }

        if (drew) ImGui.SameLine(0, 0);
        ImGui.TextColored(currentColor, subtext);
    }
}