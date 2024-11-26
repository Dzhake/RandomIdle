using System;
using ImGuiNET;

namespace RandomIdle
{
    /// <summary>
    /// ImGui component, which draws list of selectables, with names as enum values names. Please note that enum must use int
    /// </summary>
    public class EnumSelectable
    {
        private string[] choiceNames;
        private int[] choiceValues;
        public int selected;

        /// <summary>
        /// Create a new instance (for optimizing Enum.Get..()), and then use it with <see cref="Draw"/>
        /// </summary>
        /// <param name="enumType"><see cref="Type"/> of <see cref="Enum"/> to use</param>
        /// <param name="selected">Default or currently selected option, must match value's order in enum (not value itself)</param>
        /// <exception cref="ArgumentException"></exception>
        public EnumSelectable(Type enumType, int selected)
        {
            choiceNames = Enum.GetNames(enumType);
            Array values = Enum.GetValues(enumType);
            int[]? ints = values as int[];
            choiceValues = ints ?? throw new ArgumentException($"Expected values to be int, got {values.GetType().GetElementType()} instead");
            this.selected = selected;
        }

        public int Draw()
        {
            for (int i = 0; i < choiceValues.Length; i++)
            {
                if (!ImGui.Selectable(choiceNames[i], i == selected)) continue;

                selected = i;
                return choiceValues[i];
            }

            return -1;
        }
    }
}
