using ClickGame.Core;
using SDLib;
using SDLib.Resource;

namespace ClickGame.Scene.Title;

internal class Title : SceneBase
{
    public static readonly TextureManager TextureManager = new();

    public Title(IReadOnlyAppInfo info)
    {
        new MenuActor(this, info);
    }

    public override void Init(IReadOnlyAppInfo info)
    {
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
        base.Finish();
    }
}