using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomIdle;
using MenuBg = ImDrawer.MenuBg;

public static class ImPredraw
{
    public static void PreDraw()
    {
        if (ImDrawer.CurrentMenuBg == MenuBg.Water)
        {
            Drawer.SpriteBatch.Begin(SpriteSortMode.Immediate, effect: Shaders.Water);
            Rectangle bounds = Engine.graphics.GraphicsDevice.Viewport.Bounds;
            Drawer.Rect(bounds, Color.Yellow);
            Drawer.SpriteBatch.End();
        }
    }
}