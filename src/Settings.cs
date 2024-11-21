using System.Diagnostics.Contracts;
using Microsoft.Xna.Framework;
using Vector2 = System.Numerics.Vector2;

namespace RandomIdle
{
    /// <summary>
    /// Contains info which should be serialized in settings file, and which is not related to savefile
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// List of common 16:9 window sizes/resolutions
        /// </summary>
        public static Vector2[] CommonResolutions16_9 =
        {
            new (640, 360), new(1280, 720), new(1600, 900), new(1920, 1080), new(2560, 1440), new(3840,2160)
        };
        /// <summary>
        /// List of common 4:3 window sizes/resolutions
        /// </summary>
        public static Vector2[] CommonResolutions4_3 = { new (640, 480), new(800, 600), new(1600, 1200) };
        public static Vector2 WindowSize = new(1280f, 720f);


        public enum WindowType {Windowed, Maximized, Fullscreen}

        private static WindowType _window = WindowType.Maximized;

        /// <summary>
        /// Method to get current <see cref="WindowType"/>
        /// </summary>
        [Pure]
        public static WindowType GetWindowType() => _window;

        /// <summary>
        /// Method to set current <see cref="WindowType"/>
        /// </summary>
        public static void SetWindowType(WindowType type, GraphicsDeviceManager graphics)
        {
            graphics.IsFullScreen = type == WindowType.Fullscreen;
            //graphics.HardwareModeSwitch = type != WindowType.Fullscreen;
            graphics.ApplyChanges();
            _window = type;
            //Logic for Maximized is in Engine.Update()
        }
    }
}
