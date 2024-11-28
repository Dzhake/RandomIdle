using ImGuiNET;

namespace RandomIdle;

public class WaterGenerator(int level, BigDouble baseProduction, BigDouble baseCost, float costExponentBase)
{

    public int Level = level;
    public BigDouble BaseProduction = baseProduction;
    public BigDouble BaseCost = baseCost;
    public float CostExponentBase = costExponentBase;

    public BigDouble CalculateCost() => BaseCost.Multiply(new BigDouble(CostExponentBase).Pow(Level));

    public BigDouble CalculateProduction() => BaseProduction.Multiply(new(Level));

    public void Draw()
    {
        ImGui.Text($"Level: {Level}, Production: {CalculateProduction()}/s");
        ImGui.SameLine();

        if (ImGui.Button($"Upgrade: {CalculateCost()} Water")) TryBuy();
    }

    public bool TryBuy()
    {
        if (!Currencies.Water.GreaterOrEqual(CalculateCost())) return false;

        Buy();
        return true;
    }

    public void Buy()
    {
        Currencies.Water = Currencies.Water.Subtract(CalculateCost());
        Level++;
    }

    public void Update()
    {
        Currencies.Water = Currencies.Water.Add(CalculateProduction().Multiply(new(Engine.DeltaTime)));
    }
}