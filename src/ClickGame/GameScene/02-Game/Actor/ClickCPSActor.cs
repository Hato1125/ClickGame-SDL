using SDLib;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Helper;
using ClickGame.Common;

namespace ClickGame.Scenes.Game;

internal class ClickCPSActor : AppInfoActor
{
    private readonly string fontName = $"{GameInfo.FontsAsset}OPTISantita.otf";
    private readonly int fontSize = 25;

    public ClickCPSActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
        var family = new FontFamily(fontName, fontSize);
        var font = new NumberComponent(this, info, family);

        font.FontRenderer.Text = $"{GameData.GameClickCPS.ToString("#0.00")}CPS";
        font.Position = new(
            PixelHelper.GetCenter(GameInfo.FirstWindowWidth, font.FontRenderer.GetTexture().Width),
            PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 21)
        );
    }

    protected override void ActorRender()
    {
        foreach (var component in ComponentList)
        {
            if (!(component is NumberComponent))
                continue;

            var num = (NumberComponent)component;

            num.FontRenderer.Text = $"{GameData.GameClickCPS.ToString("#0.00")}CPS";
            num.Position = new(
                PixelHelper.GetCenter(GameInfo.FirstWindowWidth, num.FontRenderer.GetTexture().Width),
                PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 21)
            );
        }

        base.ActorRender();
    }
}