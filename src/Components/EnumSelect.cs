using System;
using ImGuiNET;

namespace RandomIdle
{
    public static partial class Components
    {
        /// <summary>
        /// Component, which has two buttons with arrows and text between them
        /// </summary>
        /// <param name="text">Text between buttons</param>
        /// <param name="leftCallback">Functions which is called when left arrow is pressed</param>
        /// <param name="rightCallback">Function which is called when right arrow is pressed</param>
        public static void ButtonsSelector(string text,Action leftCallback, Action rightCallback)
        {
            if (ImGui.Button("<"))
                leftCallback();
            ImGui.SameLine();
            ImGui.Text(text);
            ImGui.SameLine();
            if (ImGui.Button(">"))
                rightCallback();
        }
    }
}
