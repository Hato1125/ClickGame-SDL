using System.Drawing;
using SDLib;
using SDLib.Framework;

namespace ClickGame.Scenes.Title;

internal class FadeOutActor : Actor
{
    private IReadOnlyAppInfo _info;
    private Action? _action;
    private double _opacityCounter;
    private double _opacityValue;

    public FadeOutActor(IReadOnlyAppInfo info, Scene owner, Action? action)
        : base(owner)
    {
        _info = info;
        _action = action;

        new RectangleComponent(info, this)
        {
            X = 0,
            Y = 0,
            Width = GameInfo.FirstWindowWidth,
            Height = GameInfo.FirstWindowHeight,
            Opacity = 0,
            Color = Color.Black,
        };
    }

    protected override void ActorUpdate()
    {
        // 透明度が255になった次のフレームに実行される
        if(_opacityValue >= 255)
        {
            _action?.Invoke();
            State = ActorState.Dead;
        }

        if (_opacityCounter < 90)
            _opacityCounter += _info.DeltaTime.TotalSeconds * 50;
        else
            _opacityCounter = 90;

        _opacityValue = Math.Sin(_opacityCounter * Math.PI / 180) * 255;

        foreach (var rectComponent in ComponentList)
        {
            if (rectComponent is RectangleComponent)
            {
                var rect = (RectangleComponent)rectComponent;

                rect.Opacity = (byte)_opacityValue;
            }
        }

        base.ActorUpdate();
    }
}