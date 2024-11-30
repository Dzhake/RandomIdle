using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RandomIdle;

public static class Shaders
{
    public static Effect Water;
    public static void Intialize()
    {
        Water = Engine.Instance.Content.Load<Effect>("Shaders/Water");
    }

    public static void Update()
    {
        Rectangle window = Engine.Instance.Window.ClientBounds;
        Water.Parameters["t"].SetValue(Engine.TotalTime);
        Water.Parameters["widthToHeight"].SetValue((float)window.Width / window.Height);
    }
}