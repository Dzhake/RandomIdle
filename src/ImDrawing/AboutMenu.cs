using ImGuiNET;

namespace RandomIdle;
public static class AboutMenu
{
    public static void DrawAboutMenu()
    {
        ImDrawer.CurrentMenuBg = ImDrawer.MenuBg.None;


        ImGui.BeginTabBar("About");

        if (ImGui.BeginTabItem("Info and Help"))
        {
            ImGui.EndTabItem();
        }

        if (ImGui.BeginTabItem("Credits"))
        {
            AdvancedText.Draw("Made by {#3ba55c}Dzhake");
            ImGui.TextWrapped("\nUsed libraries/frameworks:\n" +
            "ImGui (https://github.com/ocornut/imgui)\nImGui.Net (https://github.com/ImGuiNET/ImGui.NET)\n" +
                "MonoGame.ImGuiNet (https://github.com/tsMezotic/MonoGame.ImGuiNet)\nMonoGame (https://monogame.net/)\n" +
                "SDL (https://www.libsdl.org/)\nSDL3-CS (https://github.com/flibitijibibo/SDL3-CS)\n" +
                "Part of Monocle Engine by EXOK\n\n\n\nThank you for playing :)");
            ImGui.EndTabItem();
        }

        ImGui.EndTabBar();
    }
}
