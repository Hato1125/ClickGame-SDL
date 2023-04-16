using SDLib;
using SDLib.Framework;
using ClickGame.Common;
using ClickGame.Helper;
using ClickGame.Gui;

namespace ClickGame.Scenes.Game;

internal class ClickPanelActor : AppInfoActor
{
    public ClickPanelActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
        if (TL.ClickPanel == null)
            return;

        var gui = new ImagePanel(info, TL.ClickPanel)
        {
            X = (int)PixelHelper.GetPercent(GameInfo.FirstWindowWidth, 5),
            Y = (int)PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 30),
        };
        gui.OnPushed += () =>
        {
            GameData.GameClickNum++;
        };
        new GuiComponent(this, info, gui);
    }

    protected override void ActorUpdate()
    {
        base.ActorUpdate();
    }
}