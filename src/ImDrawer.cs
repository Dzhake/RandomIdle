using System;
using ImGuiNET;

namespace RandomIdle
{
    /// <summary>
    /// Draws all the ImGui stuff, and called by <see cref="Engine"/>
    /// </summary>
    public static class ImDrawer
    {
        public static void Intialize()
        {
            windowTypeSelectable = new EnumSelectable(typeof(Settings.WindowType), (int)Settings.GetWindowType());
        }

        public static void Draw()
        {
            //ImGui.ShowDemoWindow();
            DrawMainWindow();
        }

        public static void DrawMainWindow()
        {
            ImGui.SetNextWindowSize(Engine.viewport.WorkSize);
            ImGui.SetNextWindowPos(Engine.viewport.WorkPos);
            ImGui.Begin("Main", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar
                                | ImGuiWindowFlags.NoDecoration);

            
            ImGui.End();
        }


        private static EnumSelectable windowTypeSelectable;

        public static void DrawSettingsMenu()
        {
            int selectedWindowType = windowTypeSelectable.Draw();
            if (selectedWindowType != -1) Settings.SetWindowType((Settings.WindowType)selectedWindowType, Engine.graphics);

            if (Settings.GetWindowType() == Settings.WindowType.Maximized)
            {
                ImGui.PushStyleColor(ImGuiCol.Text, Colors.Yellow);
                ImGui.Text("Warning: you may need to click \"maximize\" button for change to take effect");
                ImGui.PopStyleColor();
            }

            
        }
    }
}
