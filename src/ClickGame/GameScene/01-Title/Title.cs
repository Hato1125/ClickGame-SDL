using System.Numerics;
using SDLib;
using SDLib.Framework;
using SDLib.Resource;
using ClickGame.Helper;
using SDLib.Graphics;
using System.Drawing;

namespace ClickGame.Scenes.Title;

internal class Title : Scene
{
    public static readonly TextureManager TextureManager = new();

    public override void Init(IReadOnlyAppInfo info)
    {
        TL.Load(info);

        var logoPosition = new Vector2(
            PixelHelper.GetCenter(1280, TL.Logo != null ? TL.Logo.Width : 0),
            PixelHelper.GetPercent(720, 3)
        );

        new TextureActor(TL.Background, Vector2.Zero, this);
        new TextureActor(TL.Logo, logoPosition, this);
        new MenuActor(info, this);

        base.Init(info);
    }

    public override void Update(IReadOnlyAppInfo info)
    {
        base.Update(info);
    }

    public override void Render(IReadOnlyAppInfo info)
    {
        base.Render(info);
    }

    public override void Finish()
    {
        TextureManager.DeleteAllTexture();

        base.Finish();
    }
}