using System.Numerics;
using SDLib;
using SDLib.Framework;
using SDLib.Resource;
using ClickGame.Helper;
using ClickGame.Common;

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

        new TextureActor(this, info, TL.Background);
        new TextureActor(this, info, TL.Logo, logoPosition);
        new MenuActor(this, info);

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