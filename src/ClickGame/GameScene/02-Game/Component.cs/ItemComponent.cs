using System.Drawing;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Common;
using ClickGame.Helper;
using ClickGame.Gui;

namespace ClickGame.Scenes.Game;

internal class ItemComponent : AppInfoComponent
{
    private readonly double Weighted = 1.25;
    private readonly FontRenderer _nameFont;
    private readonly FontRenderer _detailFont;

    /// <summary>
    /// アイテム名
    /// </summary>
    public readonly string ItemName;

    /// <summary>
    /// アイテムのCPS
    /// </summary>
    public readonly double ItemCps;

    /// <summary>
    /// アイテムのアイコンテクスチャ
    /// </summary>
    public readonly Texture2D IconTexture;

    /// <summary>
    /// Gui
    /// </summary>
    public readonly ImagePanel? Gui;

    /// <summary>
    /// アイテムの数
    /// </summary>
    public long ItemNumber { get; private set; }

    /// <summary>
    /// アイテムの値段
    /// </summary>
    public long ItemPrice { get; private set; }

    public ItemComponent(
        Actor owner,
        IReadOnlyAppInfo info,
        string itemName,
        long itemPrice,
        double itemCps,
        Texture2D icon,
        long itemNum = 0)
        : base(owner, info)
    {
        ItemNumber = itemNum;
        ItemName = itemName;
        ItemPrice = itemPrice;
        ItemCps = itemCps;
        IconTexture = icon;

        if (ItemNumber > 0)
        {
            // 重みの個数分乗で値段が求められる
            ItemNumber = (long)(ItemPrice * Math.Pow(Weighted, itemNum));
        }

        var nameFamily = new FontFamily($"{GameInfo.FontsAsset}OPTISantita.otf", 20, Color.FromArgb(143, 220, 4));
        var detailFamily = new FontFamily($"{GameInfo.FontsAsset}OPTISantita.otf", 15, Color.FromArgb(143, 220, 4));
        _nameFont = new(info.RenderPtr, nameFamily) { Text = itemName };
        _detailFont = new(info.RenderPtr, detailFamily) { Text = $"{itemPrice} Click" };

        if (TL.ItemPanel != null)
        {
            Gui = new(info, TL.ItemPanel);

            var iconPositionX = PixelHelper.GetPercent(Gui.Width, 5);
            var iconPositionY = PixelHelper.GetCenter(Gui.Height, icon.Height) - 3;
            Gui.OnPaint += () =>
            {
                icon.Render(iconPositionX, iconPositionY);

                // 名前のレンダリング
                _nameFont.Render().Rotation = -7.5;
                _nameFont.GetTexture().Render(
                    PixelHelper.GetPercent(Gui.Width, 30),
                    PixelHelper.GetPercent(Gui.Height, 30)
                );

                // 値段のレンダリング
                _detailFont.Render().Rotation = -7.5;
                _detailFont.GetTexture().Render(
                    PixelHelper.GetPercent(Gui.Width, 60),
                    PixelHelper.GetPercent(Gui.Height, 17)
                );
            };
            Gui.OnSeparate += () =>
            {
                if (GameData.GameClickNum >= ItemPrice)
                {
                    GameData.GameClickNum -= ItemPrice;
                    GameData.GameClickCPS += ItemCps;

                    ItemPrice = (long)(ItemPrice * Weighted);
                    _detailFont.Text = $"{ItemPrice}Click";
                }
            };
        }
    }

    protected override void ComponentUpdate()
    {
        Gui?.Update();

        base.ComponentUpdate();
    }

    protected override void ComponentRender()
    {
        Gui?.Render();

        base.ComponentRender();
    }
}