

namespace RandomIdle
{
    public static class SaveData
    {
        public static BigDouble Water = new(1);

        public static bool AirMenuUnlocked;

        public static void Update()
        {
            if (Water.GreaterOrEqual(new(1, 10)))
                AirMenuUnlocked = true;
        }
    }
}
