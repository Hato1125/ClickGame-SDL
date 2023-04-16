using System.Numerics;
using SDLib;
using SDLib.Framework;
using SDLib.Graphics;
using ClickGame.Common;

internal class NumberComponent : AppInfoComponent
{
    /// <summary>
    /// FontRenderer
    /// </summary>
    public FontRenderer FontRenderer { get; set; }

    /// <summary>
    /// FontRendererの位置
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// FontRendererをレンダリングするか
    /// </summary>
    public bool IsView { get; set; } = true;

    /// <summary>
    /// NumberComponentを初期化する
    /// </summary>
    /// <param name="owner">Componentの持ち主のActorクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    public NumberComponent(Actor owner, IReadOnlyAppInfo info, FontFamily? fontFamily = null)
        : base(owner, info)
    {
        if (fontFamily != null)
            FontRenderer = new(info.RenderPtr, fontFamily.Value);
        else
            FontRenderer = new();
    }

    protected override void ComponentRender()
    {
        if (IsView)
        {
            FontRenderer.Render().Render(
                Position.X,
                Position.Y
            );
        }

        base.ComponentRender();
    }
}