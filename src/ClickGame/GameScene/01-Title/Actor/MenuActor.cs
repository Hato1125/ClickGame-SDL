using SDLib;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Helper;

namespace ClickGame.Scenes.Title;

internal class MenuActor : Actor
{
    public MenuActor(IReadOnlyAppInfo info, Scene owner)
        : base(owner)
    {
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
            tmpComponent.Gui.Y = (int)PixelHelper.GetPercent(720, 50) + (tmpComponent.Gui.Height - 20) * i;
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

            // guiが押されたらユーザの入力を受け付けないようにする
            if (guiCompo.Gui != null)
                if (guiCompo.Gui.IsSeparate())
                    SetGuiInput(false);

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