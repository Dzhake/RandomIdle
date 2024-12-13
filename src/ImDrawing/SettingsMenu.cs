using ImGuiNET;
using System.Numerics;

namespace RandomIdle
{
    public static class SettingsMenu
    {
        private static EnumSelectable? windowModeSelectable;

        public static void Initialize()
        {
            windowModeSelectable = new EnumSelectable(typeof(Settings.WindowMode), (int)Settings.GetWindowType());
        }

        public static void DrawSettingsMenu()
        {
            ImDrawer.CurrentMenuBg = ImDrawer.MenuBg.None;
            ImGui.SeparatorText("Video");
            ImGui.SeparatorText("Window mode");

            int selectedWindowMode = windowModeSelectable!.Draw();
            if (selectedWindowMode != -1) Settings.SetWindowType((Settings.WindowMode)selectedWindowMode);

            Settings.WindowMode windowMode = Settings.GetWindowType();

            if (windowMode == Settings.WindowMode.Maximized)
            {
                ImGui.TextColored(Colors.Yellow, 
                    "You may need to click \"maximize\" top bar button or drag window a bit for change to take effect");
            }


            ImGui.SeparatorText("Window size");

            if (windowMode != Settings.WindowMode.Windowed)
            {
                ImGui.BeginDisabled();
                ImGui.Text("You can change window size only in windowed mode.");
            }

            ImGui.InputFloat2("Window size", ref Settings.WindowSize);

            DrawResolutionButtons(ref Settings.CommonResolutions16_9);
            ImGui.Text("Common window sizes (16:9)");
            
            DrawResolutionButtons(ref Settings.CommonResolutions4_3);
            ImGui.Text("Common window sizes (4:3)");
            ImGui.Spacing();

            if (ImGui.Button("Apply")) Settings.ApplyWindowSizeChanges();

            if (windowMode != Settings.WindowMode.Windowed) ImGui.EndDisabled();

            ImGui.SeparatorText("Other");
            ImGui.Checkbox("Pause on focus loss", ref Settings.PauseOnFocusLoss);
        }

        private static void DrawResolutionButtons(ref Vector2[] resolutions)
        {
            foreach (var newResolution in resolutions)
            {
                if (ImGui.Button(newResolution.ToStringX()))
                    Settings.WindowSize = newResolution;
                ImGui.SameLine();
            }
        }
    }
}
