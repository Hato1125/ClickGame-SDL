using System.Numerics;
using System.Drawing;
using SDLib;
using SDLib.Framework;

namespace ClickGame.Common;

internal class FadeInActor : AppInfoActor
{
    private double _fadeInCounter;
    private double _fadeInValue;

    public double FadeMs { get; set; }
    public event Action? OnFinish = delegate { };

    public FadeInActor(Scene owner, IReadOnlyAppInfo info, double fadeMs = 2.5)
        : base(owner, info)
    {
        FadeMs = fadeMs;
        new RectangleComponent(this, info)
        {
            Position = Vector2.Zero,
            Size = new(GameInfo.FirstWindowWidth, GameInfo.FirstWindowHeight),
            Color = Color.Black
        };
    }

    protected override void ActorUpdate()
    {
        // フェードインが終わった次のフレームに実行
        if (_fadeInValue >= 255)
        {
            State = Actor.ActorState.Dead;
            OnFinish?.Invoke();
        }

        if (_fadeInCounter < 90)
            _fadeInCounter += (90 / FadeMs) * AppInfo.DeltaTime.TotalSeconds;
        else
            _fadeInCounter = 90;

        if (_fadeInValue < 255)
            _fadeInValue = Math.Sin(_fadeInCounter * Math.PI / 180) * 255;
        else
            _fadeInValue = 255;

        foreach (var component in ComponentList)
        {
            if (!(component is RectangleComponent))
                continue;

            var rectComponent = (RectangleComponent)component;
            rectComponent.Opacity = (byte)_fadeInValue;
        }

        base.ActorUpdate();
    }
}