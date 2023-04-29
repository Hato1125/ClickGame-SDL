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

        new TextureActor(this, info, TL.Background);
        new TitlePanelActor(this, info);
        new MenuActor(this, info);

        base.Init(info);
    }

    public override void Finish()
    {
        TextureManager.DeleteAllTexture();

        base.Finish();
    }
}