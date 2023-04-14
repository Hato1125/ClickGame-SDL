using System.Numerics;
using System.Drawing;
using SDLib;
using SDLib.Framework;

namespace ClickGame.Common;

internal class FadeOutActor : AppInfoActor
{
    private double _fadeOutCounter;
    private double _fadeOutValue;

    public double FadeMs { get; set; }
    public event Action? OnFinish = delegate { };

    public FadeOutActor(Scene owner, IReadOnlyAppInfo info, double fadeMs = 2.5)
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
        // フェードアウトが終わった次のフレームに実行
        if(_fadeOutValue >= 255)
            OnFinish?.Invoke();

        if(_fadeOutCounter < 90)
            _fadeOutCounter += (90 / FadeMs) * AppInfo.DeltaTime.TotalSeconds;
        else
            _fadeOutCounter = 90;

        if(_fadeOutValue < 255)
            _fadeOutValue = Math.Sin(_fadeOutCounter * Math.PI / 180) * 255;
        else
            _fadeOutCounter = 255;

        foreach(var component in ComponentList)
        {
            if(!(component is RectangleComponent))
                continue;

            var rectComponent = (RectangleComponent)component;
            rectComponent.Opacity = (byte)_fadeOutValue;
        }

        base.ActorUpdate();
    }
}