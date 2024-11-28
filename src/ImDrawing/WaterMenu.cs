using System.Collections.Generic;
using ImGuiNET;

namespace RandomIdle;

public static class WaterMenu
{
    public static List<WaterGenerator> Generators = [ new(0, 1, 1, 1.1f) ];

    public static void DrawWaterMenu()
    {
        ImGui.PushStyleColor(ImGuiCol.Button, Colors.Blue);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Colors.LightBlue);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, Colors.LigherBlue);

        ImGui.Text(Currencies.Water.ToString());
        foreach (WaterGenerator generator in Generators)
        {
            if (generator.Level < 1) break;
            generator.Draw();
        }

        ImGui.PopStyleColor(3);
    }

    public static void Update()
    {
        foreach (WaterGenerator generator in Generators)
        {
            if (generator.Level < 1) break;
            generator.Update();
        }
    }
}