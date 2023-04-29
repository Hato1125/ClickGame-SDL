using SDLib;
using SDLib.Framework;
using SDLib.Resource;
using ClickGame.Common;

namespace ClickGame.Scenes.Game;

internal class Game : Scene
{
    public static readonly TextureManager TextureManager = new();

    public override void Init(IReadOnlyAppInfo info)
    {
        TL.Load(info);

        new TextureActor(this, info, TL.Background);
        new ClickPanelActor(this, info);
        new ClickNumActor(this, info);
        new ClickCPSActor(this, info);
        new ItemShopActor(this, info);

        base.Init(info);
    }

    public override void Finish()
    {
        TextureManager.DeleteAllTexture();

        base.Finish();
    }
}