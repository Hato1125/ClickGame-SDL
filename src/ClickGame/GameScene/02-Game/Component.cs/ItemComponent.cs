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
    private readonly FontRenderer _nameFont;
    private readonly FontRenderer _detailFont;

    public readonly string ItemName;
    public readonly double ItemPrice;
    public readonly double ItemCps;
    public readonly Texture2D IconTexture;
    public readonly ImagePanel? Gui;

    public ItemComponent(Actor owner, IReadOnlyAppInfo info, string itemName, double itemPrice, double itemCps, Texture2D icon)
        : base(owner, info)
    {
        ItemName = itemName;
        ItemPrice = itemPrice;
        ItemCps = itemCps;
        IconTexture = icon;

        var nameFamily = new FontFamily($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf", 20, Color.White);
        var detailFamily = new FontFamily($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf", 15, Color.White);
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
                if(GameData.GameClickNum >= ItemPrice)
                {
                    GameData.GameClickNum -= ItemPrice;
                    GameData.GameClickCPS += ItemCps;
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