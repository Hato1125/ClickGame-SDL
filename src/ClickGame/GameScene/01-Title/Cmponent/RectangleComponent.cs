using System.Drawing;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame.Scenes.Title;

internal class RectangleComponent : Component
{
    private IReadOnlyAppInfo _info;

    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public byte Opacity { get; set; }
    public Color Color { get; set; }

    public RectangleComponent(IReadOnlyAppInfo info, Actor owner)
        : base(owner)
    {
        _info = info;
    }

    protected override void ComponentRender()
    {
        Shape.RenderRect(_info.RenderPtr, X, Y, Width, Height, Color, Opacity);
        base.ComponentRender();
    }
}