using System.Numerics;
using SDLib.Graphics;

namespace ClickGame.Core;

internal class SpriteComponent : RenderComponent
{
    /// <summary>
    /// スプライト
    /// </summary>
    public Texture2D? Sprite { get; set; }

    /// <summary>
    /// スプライトを連打する位置
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// Spriteコンポーネントを初期化する
    /// </summary>
    /// <param name="actor">コンポーネントの持ち主</param>
    public SpriteComponent(Actor actor)
        : base(actor)
    {
    }

    /// <summary>
    /// コンポーネントをレンダリングする
    /// </summary>
    public override void RednerComponent()
    {
        Sprite?.Render(Position.X, Position.Y);
        base.RednerComponent();
    }
}