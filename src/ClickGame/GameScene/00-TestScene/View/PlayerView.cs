using SDLib.Graphics;

namespace ClickGame.Scene.Test.View;

internal class PlayerView
{
    public void Render(Texture2D texture, float x, float y)
    {
        texture.Render(x, y);
    }
}