using System.Collections.Generic;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomIdle;

public static class WaterMenu
{
    public static readonly List<WaterGenerator> Generators = [ new(0, 1, 1, 1.1f) ];
    private static bool selected;

    public static void DrawWaterMenu()
    {
        selected = true;
        ImGui.PushStyleColor(ImGuiCol.Button, Colors.Blue);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, Colors.LightBlue);
        ImGui.PushStyleColor(ImGuiCol.ButtonActive, Colors.LigherBlue);

        foreach (WaterGenerator generator in Generators)
        {
            generator.Draw();
            if (generator.Level < 1) break;
        }

        ImGui.PopStyleColor(3);
    }

    public static void PreDraw()
    {
        if (selected)
        {
            Drawer.SpriteBatch.Begin(SpriteSortMode.Immediate, effect: Shaders.Water);
            Rectangle bounds = Engine.graphics.GraphicsDevice.Viewport.Bounds;
            Drawer.Rect(bounds, Color.Yellow);
            Drawer.SpriteBatch.End();
        }
        selected = false;
    }

    public static void Update()
    {
        foreach (WaterGenerator generator in Generators)
        {
            generator.Update();
            if (generator.Level < 1) break;
        }
    }
}