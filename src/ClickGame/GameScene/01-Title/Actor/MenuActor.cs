using SDLib;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Helper;

namespace ClickGame.Scenes.Title;

internal class MenuActor : Actor
{
    private IReadOnlyAppInfo _info;

    public MenuActor(IReadOnlyAppInfo info, Scene owner)
        : base(owner)
    {
        _info = info;

        if (TL.StartButton == null
            || TL.SettingButton == null
            || TL.ExitButton == null)
            return;

        var buttonTextures = new Texture2D[]
        {
            TL.StartButton,
            TL.SettingButton,
            TL.ExitButton
        };

        MenuComponent? tmpComponent;
        for (int i = 0; i < buttonTextures.Length; i++)
        {
            tmpComponent = new(this);
            tmpComponent.Gui = new(info, buttonTextures[i]);
            tmpComponent.Gui.X = (int)PixelHelper.GetCenter(1280, tmpComponent.Gui.Width);
            tmpComponent.Gui.Y = (int)PixelHelper.GetPercent(720, 50) + tmpComponent.Gui.Height * i;
        }
        tmpComponent = null;
    }

    protected override void ActorUpdate()
    {
        base.ActorUpdate();

        foreach (var component in ComponentList)
        {
            if (!(component is MenuComponent))
                continue;

            var guiCompo = (MenuComponent)component;

            if (guiCompo.Gui == null)
                continue;

            // guiが押されたらユーザの入力を受け付けないようにする
            if (guiCompo.Gui.IsSeparate())
            {
                SetGuiInput(false);

                // フェードアウト用のActorを追加
                new FadeOutActor(_info, Owner, () =>
                {
                    SceneManager.SetScene("Game");
                });
            }

        }
    }

    private void SetGuiInput(bool isInput)
    {
        foreach (var component in ComponentList)
        {
            if (!(component is MenuComponent))
                continue;

            var guiCompo = (MenuComponent)component;

            if (guiCompo.Gui != null)
                guiCompo.Gui.IsInput = isInput;
        }
    }
}