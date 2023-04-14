using System.Numerics;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame.Common;

internal class TextureActor : AppInfoActor
{
    /// <summary>
    /// Texture
    /// </summary>
    public readonly Texture2D? Texture;

    /// <summary>
    /// TextureActorを初期化する
    /// </summary>
    /// <param name="owner">Actorの持ち主のSceneクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    /// <param name="texture">Texture</param>
    /// <param name="position">Textureの位置</param>
    public TextureActor(Scene owner, IReadOnlyAppInfo info, Texture2D? texture, Vector2? position = null)
        : base(owner, info)
    {
        if(texture == null)
            return;

        var textureComponent = new TextureComponent(this, info, texture)
        {
            Position = new(
                position != null ? position.Value.X : 0,
                position != null ? position.Value.Y : 0
            ),
        };

        Texture = textureComponent.Texture;
    }
}