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

            ImGui.BeginTabBar("MainBar", ImGuiTabBarFlags.Reorderable);

            ImGui.BeginTabItem("Water");

            ImGui.EndTabItem();

            ImGui.BeginTabItem("Settings");
            SettingsMenu.DrawSettingsMenu();
            ImGui.EndTabItem();

            ImGui.EndTabBar();
            ImGui.End();
        }
    }
}
