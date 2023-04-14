using System.Numerics;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame.Common;

internal class TextureComponent : AppInfoComponent
{
    /// <summary>
    /// Texture
    /// </summary>
    public Texture2D Texture { get; set; }

    /// <summary>
    /// Textureの位置
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// Textureをレンダリングするか
    /// </summary>
    public bool IsView { get; set; } = true;

    /// <summary>
    /// TextureComponentを初期化する
    /// </summary>
    /// <param name="owner">Componentの持ち主のActorクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    /// <param name="texture">Texture</param>
    public TextureComponent(Actor owner, IReadOnlyAppInfo info, Texture2D texture)
        : base(owner, info)
        => Texture = texture;

    /// <summary>
    /// TextureComponentを初期化する
    /// </summary>
    /// <param name="owner">Componentの持ち主のActorクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    /// <param name="filePath">ファイルパス</param>
    public TextureComponent(Actor owner, IReadOnlyAppInfo info, string filePath)
        : base(owner, info)
        => Texture = new(info.RenderPtr, filePath);

    protected override void ComponentRender()
    {
        if (IsView)
            Texture.Render(Position.X, Position.Y);

        base.ComponentRender();
    }
}