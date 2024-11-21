using ImGuiNET;
using System.Numerics;

namespace RandomIdle
{
    public static class SettingsMenu
    {
        private static EnumSelectable? windowTypeSelectable;

        public static void Initialize()
        {
            windowTypeSelectable = new EnumSelectable(typeof(Settings.WindowType), (int)Settings.GetWindowType());
        }

        public static void DrawSettingsMenu()
        {
            ImGui.SeparatorText("Video");
            ImGui.SeparatorText("Window type");

            int selectedWindowType = windowTypeSelectable!.Draw();
            if (selectedWindowType != -1) Settings.SetWindowType((Settings.WindowType)selectedWindowType, Engine.graphics);

            if (Settings.GetWindowType() == Settings.WindowType.Maximized)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Colors.Yellow);
                ImGui.Text("Warning: you may need to click \"maximize\" button for change to take effect");
                ImGui.PopStyleColor();
            }

            ImGui.SeparatorText("Window size");
            ImGui.InputFloat2("Window size/resolution", ref Settings.WindowSize);

            DrawResolutionButtons(ref Settings.CommonResolutions16_9);
            ImGui.Text("Common window sizes/resolutions (16:9)");
            
            DrawResolutionButtons(ref Settings.CommonResolutions4_3);
            ImGui.Text("Common window sizes/resolutions (4:3)");
            ImGui.Spacing();

            if (ImGui.Button("Apply"))
            {
                Engine.graphics.PreferredBackBufferWidth = (int)Settings.WindowSize.X;
                Engine.graphics.PreferredBackBufferHeight = (int)Settings.WindowSize.Y;
                Engine.graphics.ApplyChanges();
            }
        }

        private static void DrawResolutionButtons(ref Vector2[] resolutions)
        {
            for (int i = 0; i < resolutions.Length; i++)
            {
                Vector2 newResolution = resolutions[i];
                if (ImGui.Button(newResolution.ToStringX()))
                    Settings.WindowSize = newResolution;
                ImGui.SameLine();
            }
        }
    }
}
