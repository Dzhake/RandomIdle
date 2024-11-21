using ImGuiNET;
using System.Numerics;

namespace RandomIdle
{
    /// <summary>
    /// Draws all the ImGui stuff, and called by <see cref="Engine"/>
    /// </summary>
    public static class ImDrawer
    {
        public static void Intialize()
        {
            SettingsMenu.Initialize();
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

            SettingsMenu.DrawSettingsMenu();

            ImGui.End();
        }
    }
}
