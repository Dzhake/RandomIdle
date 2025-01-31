﻿using System.Numerics;
using ImGuiNET;

namespace RandomIdle
{
    /// <summary>
    /// Draws all the ImGui stuff, and called by <see cref="Engine"/>
    /// </summary>
    public static class ImDrawer
    {
        public enum MenuBg {None, Water}

        public static MenuBg CurrentMenuBg = MenuBg.None;

        public static void Intialize()
        {
            SettingsMenu.Initialize();
        }

        public static void Draw()
        {
            DrawMainWindow();
            DrawCurrenciesWindow();
            //ImGui.ShowDemoWindow();
        }

        public static void DrawMainWindow()
        {
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0f,0f,0f,0.7f));
            ImGui.SetNextWindowSize(Engine.viewport.WorkSize with { X = Engine.viewport.WorkSize.X * 0.8f });
            ImGui.SetNextWindowPos(Engine.viewport.WorkPos with { X = Engine.viewport.WorkSize.X * 0.2f });
            ImGui.Begin("Main", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar
                                | ImGuiWindowFlags.NoDecoration);

            ImGui.BeginTabBar("MainBar", ImGuiTabBarFlags.Reorderable);

            Colors.PushNeutralColors();
            if (ImGui.BeginTabItem("Game"))
            {
                DrawGameBar();
                ImGui.EndTabItem();
            }
            Colors.PopColors();
            
            Colors.PushNeutralColors();
            if (ImGui.BeginTabItem("Settings"))
            {
                SettingsMenu.DrawSettingsMenu();
                ImGui.EndTabItem();
            }

            if (ImGui.BeginTabItem("About"))
            {
                AboutMenu.DrawAboutMenu();
                ImGui.EndTabItem();
            }
            Colors.PopColors();

            ImGui.EndTabBar();
            ImGui.End();
            ImGui.PopStyleColor();
        }

        private static void DrawGameBar()
        {
            ImGui.BeginTabBar("Game");

            Colors.PushWaterColors();
            if (ImGui.BeginTabItem("Water"))
            {
                WaterMenu.DrawWaterMenu();
                ImGui.EndTabItem();
            }
            Colors.PopColors();

            if (SaveData.AirMenuUnlocked && ImGui.BeginTabItem("Air"))
            {
                ImGui.Text(":3");
                ImGui.EndTabItem();
            }

            ImGui.EndTabBar();
        }


        public static void DrawCurrenciesWindow()
        {
            ImGui.SetNextWindowSize(Engine.viewport.WorkSize with { X = Engine.viewport.WorkSize.X * 0.2f });
            ImGui.SetNextWindowPos(Engine.viewport.WorkPos);
            ImGui.Begin("Currencies", ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoTitleBar
                                | ImGuiWindowFlags.NoDecoration);

            ImGui.PushStyleColor(ImGuiCol.Text, Colors.LighterBlue);
            ImGui.TextWrapped($"Water: {SaveData.Water}; {WaterMenu.WaterGain}/s");
            ImGui.PopStyleColor();

            ImGui.End();
        }
    }

}
