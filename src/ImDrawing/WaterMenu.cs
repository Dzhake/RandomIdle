using System.Collections.Generic;
using ImGuiNET;
using MonoPlus;

namespace RandomIdle;

public static class WaterMenu
{
    public static readonly List<WaterGenerator> Generators = [
        new(1, 1, 1.01f),
        new(10, 1e3, 1.1f),
        new(50, 1e5, 1.1f),
        new(1e3, 1e5, 1.3f),
        new(1e3, 1e7, 1.01f),
        new(1e5,1e9, 1.5f)
    ];

    public static BigDouble WaterGain;

    public static void DrawWaterMenu()
    {
        ImDrawer.CurrentMenuBg = ImDrawer.MenuBg.Water;

        ImGui.TextWrapped("Smaller rivers flow into bigger rivers, increasing their production.");
        ImGui.Separator();

        for (int i = 0; i < Generators.Count; i++)
        {
            WaterGenerator generator = Generators[i];
            ImGui.PushID(i);
            generator.Draw();
            ImGui.PopID();
            if (generator.Amount <= 0) break;
        }
    }

    public static void Update()
    {
        float mult = 1f;
        BigDouble gainPS = new();
        for (int i = 0; i < Generators.Count; i++)
        {
            var generator = Generators[i];
            generator.ProductionMultiplier = mult;
            gainPS += generator.CalculateProduction();
            mult += generator.Amount * (i + 1);

            if (Engine.kb.IsKeyDown(InputHelper.NumberKeys[i]))
            {
                if (Engine.kb.IsShiftDown())
                    generator.TryBuy();
                else
                    generator.BuyMax();
            }

            if (generator.Amount <= 0) break;
        }

        WaterGain = gainPS;
        SaveData.Water += gainPS.Multiply(new(Engine.DeltaTime));
    }
}