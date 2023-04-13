using System.Numerics;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame.Scenes.Title;

internal class TextureActor : Actor
{
    public TextureActor(Texture2D? texture, Vector2 position, Scene owner)
        : base(owner)
    {
        if (texture != null)
        {
            new TextureComponent(this)
            {
                Texture = texture,
                Position = position
            };
        }
    }
}