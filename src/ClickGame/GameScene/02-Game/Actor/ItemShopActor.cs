using SDLib;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Helper;
using ClickGame.Common;

namespace ClickGame.Scenes.Game;

internal class ItemShopActor : AppInfoActor
{
    private readonly string[] _names = new string[]
    {
        "Clicker",
        "TwinClicker",
        "Plant",
        "Mine",
        "Bank"
    };

    private readonly long[] _prices = new long[]
    {
        10,
        65,
        500,
        2000,
        10000,
    };

    private readonly double[] _cpss = new double[]
    {
        0.1,
        1.0,
        4.5,
        10.0,
        100.0,
    };

    private readonly Texture2D?[] _icons = new Texture2D?[]
    {
        TL.ClickerIcon,
        TL.DummyIcon,
        TL.DummyIcon,
        TL.DummyIcon,
        TL.DummyIcon,
    };

    public ItemShopActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
        if (TL.DummyIcon != null)
        {
            for (int i = 0; i < _names.Length; i++)
                new ItemComponent(this, info, _names[i], _prices[i], _cpss[i], _icons[i] ?? TL.DummyIcon);
        }
    }

    protected override void ActorUpdate()
    {
        for (int i = 0; i < ComponentList.Count; i++)
        {
            if (!(ComponentList[i] is ItemComponent))
                continue;

            var item = (ItemComponent)ComponentList[i];

            if (item.Gui != null)
            {
                item.Gui.X = (int)PixelHelper.GetPercent(GameInfo.FirstWindowWidth, 60);
                item.Gui.Y = (int)PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 10) + i * (item.Gui.Height + 10);
            }
        }

        base.ActorUpdate();
    }
}