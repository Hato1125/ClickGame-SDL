using System.Diagnostics;
using SDL2;
using SDLib;
using SDLib.Framework;
using ClickGame.Common;
using ClickGame.Helper;
using ClickGame.Gui;

namespace ClickGame.Scenes.Game;

internal class ClickPanelActor : AppInfoActor
{
    private readonly Stopwatch _cpsStopwatch = new();

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
        gui.KeyCode.Add(SDL.SDL_Scancode.SDL_SCANCODE_SPACE);
        new GuiComponent(this, info, gui);
    }

    protected override void ActorUpdate()
    {
        if (GameData.GameClickCPS > 0.0)
        {
            if (!_cpsStopwatch.IsRunning)
                _cpsStopwatch.Start();

            // 指定時間に+1づつやってもいいがFPSの都合上どうしても速さに上限があるため
            // 一秒間隔でCPSを足していく
            if (_cpsStopwatch.Elapsed.TotalSeconds >= 1)
            {
                GameData.GameClickNum += GameData.GameClickCPS;
                _cpsStopwatch.Stop();
                _cpsStopwatch.Reset();
            }
        }

        base.ActorUpdate();
    }
}