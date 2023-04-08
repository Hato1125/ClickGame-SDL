using ClickGame.Core;
using SDLib;
using SDLib.Graphics;
using SDLib.Resource;

namespace ClickGame.Scene.Test;

internal class Test : SceneBase
{
    public static readonly TextureManager TextureManager = new();

    public Test(IReadOnlyAppInfo info)
    {
        Children.Add(new Player(info));
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
        TextureManager.DeleteAllTexture();

        base.Finish();
    }

    public static int Entitys;
    public static int CreateEntity()
    {
        Entitys++;
        return Entitys - 1;
    }
}