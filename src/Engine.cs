using System;
using System.Diagnostics;
using System.IO;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.ImGuiNet;
using SDL2;

namespace RandomIdle
{
    /// <summary>
    /// Class which calls <see cref="ImDrawer.Draw"/>, and contains main ImGui variables
    /// </summary>
    public class Engine : Game
    {
        public static Engine Instance;
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch _spriteBatch;
        public static ImGuiRenderer GuiRenderer;

        public static IntPtr SDLWindow => Instance.Window.Handle;
        public static ImGuiIOPtr io;
        public static ImGuiViewportPtr viewport;
        public static ImGuiStylePtr style;

        private static readonly string errorLogPath = AppContext.BaseDirectory + "error.txt";

        public Engine()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.AllowUserResizing = true;
            Window.Title = "Random Idle";

            SDL.SDL_SetWindowPosition(Window.Handle, 0, 20);
            
            GuiRenderer = new ImGuiRenderer(this);
            io = ImGui.GetIO();
            viewport = ImGui.GetMainViewport();
            style = ImGui.GetStyle();

            style.FrameRounding = 3f;
            style.WindowBorderSize = 0f;

            ImDrawer.Intialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GuiRenderer.RebuildFontAtlas();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Settings.GetWindowType() == Settings.WindowType.Maximized)
                SDL.SDL_MaximizeWindow(SDLWindow);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
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
    }
}
