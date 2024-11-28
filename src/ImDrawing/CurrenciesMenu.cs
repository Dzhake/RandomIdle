using ImGuiNET;

namespace RandomIdle;

public static class CurrenciesMenu
{
    public static void Draw()
    {
        ImGui.PushStyleColor(ImGuiCol.Text, Colors.LigherBlue);
        ImGui.Text($"Water: {Currencies.Water}");
        ImGui.PopStyleColor();
    }
}