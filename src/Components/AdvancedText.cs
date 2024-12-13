using System;
using System.Numerics;
using System.Text;
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
        StringBuilder subtext = new();
        Vector4 currentColor = Vector4.One;
        bool drew = false;

        while (i < text.Length)
        {
            char symbol = text[i];
            switch (symbol)
            {
                case '{':
                {
                    if (drew) ImGui.SameLine(0, 0);

                    else if (currentColor == Vector4.One)
                        ImGui.Text(subtext.ToString());
                    else
                        ImGui.TextColored(currentColor, subtext.ToString());
                    drew = true;
                    subtext.Clear();
                    break;
                }
                case '}':
                    if (subtext.ToString() == "#")
                        currentColor = Vector4.One;
                    else if (subtext.ToString().StartsWith('#'))
                        currentColor = Colors.ParseHex(subtext.ToString());

                    subtext.Clear();
                    break;
                default:
                    subtext.Append(symbol);
                    break;
            }
            i++;
        }

        if (drew) ImGui.SameLine(0, 0);
        ImGui.TextColored(currentColor, subtext.ToString());
    }
}