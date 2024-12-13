using ImGuiNET;

namespace RandomIdle;

public class WaterGenerator : BaseGenerator
{
    public WaterGenerator(BigDouble baseProduction, BigDouble baseCost, float costExponentBase, float amount = 0f)
        : base(baseProduction, baseCost, costExponentBase, amount)
    {
        CurrencyName = "Water";
    }

    public override BigDouble Currency { get => SaveData.Water; set => SaveData.Water = value; }

    public override void Draw()
    {
        ImGui.Text($"Amount: {Amount}, Production: {CalculateProduction()}/s");
        if (ImGui.BeginItemTooltip())
        {
            ImGui.Text($"{BaseProduction} * {ProductionMultiplier} * {Amount}\nbase * mult * amount");
            ImGui.EndTooltip();
        }

        if (ImGui.Button($"Buy: {CalculateCost()} {CurrencyName}")) TryBuy();
        ImGui.SameLine();
        if (ImGui.Button("Buy Max")) BuyMax();
    }
}