using System.Numerics;
using System.Drawing;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame.Common;

internal class RectangleComponent : AppInfoComponent
{
    /// <summary>
    /// 矩形の位置
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// 矩形のサイズ
    /// </summary>
    public Vector2 Size { get; set; }

    /// <summary>
    /// 矩形の色
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// 矩形の透明度
    /// </summary>
    public byte Opacity { get; set; } = 255;

    /// <summary>
    /// 矩形を表示するか
    /// </summary>
    public bool IsView { get; set; } = true;

    /// <summary>
    /// RectangleComponentを初期化する
    /// </summary>
    /// <param name="owner">Componentの持ち主のActorクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    public RectangleComponent(Actor owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
    }

    protected override void ComponentRender()
    {
        if(IsView)
        {
            if(Color != Color.Empty && Opacity > 0)
            {
                Shape.RenderRect(
                    AppInfo.RenderPtr,
                    (int)Position.X,
                    (int)Position.Y,
                    (int)Size.X,
                    (int)Size.Y,
                    Color,
                    Opacity
                );
            }
        }

        base.ComponentRender();
    }
}