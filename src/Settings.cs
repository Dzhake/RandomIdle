using Microsoft.Xna.Framework;

namespace RandomIdle
{
    /// <summary>
    /// Contains info which should be serialized in settings file, and which is not related to savefile
    /// </summary>
    public static class Settings
    {
        public enum WindowType {Windowed, Maximized, Fullscreen}

        private static WindowType _window = WindowType.Maximized;

        /// <summary>
        /// Method to get current <see cref="WindowType"/>
        /// </summary>
        public static WindowType GetWindowType() => _window;

        /// <summary>
        /// Method to set current <see cref="WindowType"/>
        /// </summary>
        public static void SetWindowType(WindowType type, GraphicsDeviceManager graphics)
        {
            graphics.IsFullScreen = type == WindowType.Fullscreen;
            graphics.HardwareModeSwitch = type != WindowType.Fullscreen;
            graphics.ApplyChanges();
            _window = type;
            //Logic for Maximized is in Engine.Update()
        }
    }
}
