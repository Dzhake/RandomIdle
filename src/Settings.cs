using System.Diagnostics.Contracts;
using SDL2;
using Vector2 = System.Numerics.Vector2;

namespace RandomIdle
{
    /// <summary>
    /// Contains info which should be serialized in settings file, and which is not related to savefile
    /// </summary>
    public static class Settings
    {
        public enum WindowMode {Windowed, Maximized, Fullscreen}

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
        private static WindowMode _window = WindowMode.Windowed;
        public static bool PauseOnFocusLoss;

        /// <summary>
        /// Method to get current <see cref="WindowMode"/>
        /// </summary>
        [Pure]
        public static WindowMode GetWindowType() => _window;

        /// <summary>
        /// Method to set current <see cref="WindowMode"/>
        /// </summary>
        public static void SetWindowType(WindowMode mode)
        {
            var graphics = Engine.graphics;

            if (mode == WindowMode.Windowed)
            {
                SDL.SDL_RestoreWindow(Engine.SDLWindow);
                WindowSize = new(1280, 720);
                ApplyWindowSizeChanges();
            }

            graphics.IsFullScreen = mode == WindowMode.Fullscreen;
            graphics.HardwareModeSwitch = mode != WindowMode.Fullscreen;
            if (mode == WindowMode.Fullscreen)
            {
                var window = Engine.Instance.Window.ClientBounds;
                graphics.PreferredBackBufferWidth = window.Width;
                graphics.PreferredBackBufferHeight = window.Height;
            }
            graphics.ApplyChanges();
            _window = mode;
            //Logic for Maximized is in Engine.Update()
        }

        /// <summary>
        /// Changes PreferredBackBuffer sizes and centers game's window in windowed mode
        /// </summary>
        public static void ApplyWindowSizeChanges()
        {
            Engine.graphics.PreferredBackBufferWidth = (int)WindowSize.X;
            Engine.graphics.PreferredBackBufferHeight = (int)WindowSize.Y;
            SDL.SDL_GetCurrentDisplayMode(0, out var displayMode);
            Vector2 windowPos = (new Vector2(displayMode.w, displayMode.h) - WindowSize) / 2;
            Engine.Instance.Window.Position = windowPos.ToPoint();
            Engine.graphics.ApplyChanges();
        }

        public static void Save()
        {

        }

        public static void Load()
        {

        }
    }
}
