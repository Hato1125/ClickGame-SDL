using System.Drawing;
using SDLib;
using SDLib.Framework;
using SDLib.Graphics;
using ClickGame.Helper;
using ClickGame.Common;

namespace ClickGame.Scenes.Game;

internal class ClickNumActor : AppInfoActor
{
    private readonly string fontName = $"{GameInfo.FontsAsset}OPTISantita.otf";
    private readonly int fontSize = 70;

    public ClickNumActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
        var family = new FontFamily(fontName, fontSize);
        var font = new NumberComponent(this, info, family);

        font.FontRenderer.Text = ((long)GameData.GameClickNum).ToString();
        font.Position = new(
            PixelHelper.GetCenter(GameInfo.FirstWindowWidth, font.FontRenderer.GetTexture().Width),
            PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 10)
        );
    }

    protected override void ActorUpdate()
    {
        foreach (var component in ComponentList)
        {
            if (!(component is NumberComponent))
                continue;

            var num = (NumberComponent)component;

            // クリックされた回数が少数なのはおかしいからlongにキャスト
            var clickNum = (long)GameData.GameClickNum;

            if (num.FontRenderer.Text != clickNum.ToString())
            {
                if (clickNum >= 1000000)
                    num.FontRenderer.FontFamily = new(fontName, fontSize, Color.Gold);
                else if (clickNum >= 100000)
                    num.FontRenderer.FontFamily = new(fontName, fontSize, Color.Orange);
                else if (clickNum >= 10000)
                    num.FontRenderer.FontFamily = new(fontName, fontSize, Color.Yellow);
                else if (clickNum >= 1000)
                    num.FontRenderer.FontFamily = new(fontName, fontSize, Color.LightYellow);
                else
                    num.FontRenderer.FontFamily = new(fontName, fontSize, Color.White);

                num.FontRenderer.Text = clickNum.ToString();
            }

            num.Position = new(
                PixelHelper.GetCenter(GameInfo.FirstWindowWidth, num.FontRenderer.GetTexture().Width),
                PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 10)
            );
        }

        base.ActorUpdate();
    }

    protected override void ActorRender()
    {
        base.ActorRender();
    }
}