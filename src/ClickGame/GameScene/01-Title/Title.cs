using ClickGame.Core;
using SDLib;
using SDLib.Resource;

namespace ClickGame.Scene.Title;

internal class Title : SceneBase
{
    public static readonly TextureManager TextureManager = new();

    private MenuActor? _menuActor;

    public Title(IReadOnlyAppInfo info)
    {
        _menuActor = new(this, info);
    }

    public override void Init(IReadOnlyAppInfo info)
    {
        if(_menuActor == null){
            _menuActor = new(this, info);
        }

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
        if(_menuActor != null)
            _menuActor = null;

        base.Finish();
    }
}