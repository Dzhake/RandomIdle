using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using ImGuiNET;
using Microsoft.Xna.Framework;
using MonoGame.ImGuiNet;
using SDL2;

namespace RandomIdle
{
    /// <summary>
    /// Class which calls <see cref="ImDrawer.Draw"/>, and contains main ImGui variables
    /// </summary>
    public class Engine : Game
    {
        public static GraphicsDeviceManager graphics;
        public static ImGuiRenderer GuiRenderer;
        public static Engine Instance;
        
        public static IntPtr SDLWindow => Instance.Window.Handle;
        public static ImGuiIOPtr io;
        public static ImGuiViewportPtr viewport;
        public static ImGuiStylePtr style;

        public static TimeSpan DeltaTimeSpan;
        public static float DeltaTime => DeltaTimeSpan.Milliseconds / 1000f;
        public static TimeSpan TotalTime;


        private static readonly string errorLogPath = AppContext.BaseDirectory + "error.txt";

        public Engine()
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            Content.RootDirectory = "Content";
            Instance = this;
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            graphics = new(this);
        }

        protected override void Initialize()
        {
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += Window_ClientSizeChanged;
            Window.Title = "Random Idle";
            
            GuiRenderer = new ImGuiRenderer(this);
            io = ImGui.GetIO();
            viewport = ImGui.GetMainViewport();
            style = ImGui.GetStyle();
            style.FrameRounding = 3f;
            style.WindowBorderSize = 0f;

            ImDrawer.Intialize();
            Drawer.Initialize(graphics.GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            GuiRenderer.RebuildFontAtlas();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Settings.PauseOnFocusLoss && !IsActive) return;

            DeltaTimeSpan = gameTime.ElapsedGameTime;
            TotalTime = gameTime.TotalGameTime;


            if (Settings.GetWindowType() == Settings.WindowMode.Maximized)
            {
                SDL.SDL_MaximizeWindow(SDLWindow);
            }

            WaterMenu.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Settings.PauseOnFocusLoss && !IsActive)
                return;

            try
            {
                GraphicsDevice.Clear(Color.Black);
                base.Draw(gameTime);

                GuiRenderer.BeginLayout(gameTime);
                ImDrawer.Draw();
                GuiRenderer.EndLayout();
            }
            catch (Exception ex)
            {
                File.WriteAllText(errorLogPath, $"{DateTime.Now}\n{ex}");
                var psi = new ProcessStartInfo(errorLogPath)
                {
                    UseShellExecute = true
                };

                Process.Start(psi);
                Exit();
            }
        }


        private void Window_ClientSizeChanged(object? sender, EventArgs e)
        {
            var window = Window.ClientBounds;
            Settings.WindowSize.X = window.Width;
            Settings.WindowSize.Y = window.Height;
        }
    }
}
