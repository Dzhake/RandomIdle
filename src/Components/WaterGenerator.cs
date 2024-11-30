using ImGuiNET;
using Microsoft.Xna.Framework;

namespace RandomIdle;

public class WaterGenerator : BaseGenerator
    
{
    public WaterGenerator(int level, BigDouble baseProduction, BigDouble baseCost, float costExponentBase)
        : base(level, baseProduction, baseCost, costExponentBase)
    {
        CurrencyName = "Water";
    }

    public override BigDouble Currency { get => Currencies.Water; set => Currencies.Water = value; }

    public override void Draw()
    {
        ImGui.Text($"Level: {Level}, Production: {CalculateProduction()}/s");

        if (ImGui.Button($"Upgrade: {CalculateCost()} {CurrencyName}")) TryBuy();

    }

    public override void Update()
    {
        Currency = Currency.Add(CalculateProduction().Multiply(new(Engine.DeltaTime)));
    }
}