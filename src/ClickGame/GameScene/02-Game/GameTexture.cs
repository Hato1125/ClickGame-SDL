using SDLib;
using SDLib.Graphics;

namespace ClickGame.Scenes.Game;

internal static class TL
{
    private static readonly string GameGraphics = $"{GameInfo.GraphicsAsset}02-Game\\";

    public static Texture2D? Background;
    public static Texture2D? ClickPanel;
    public static Texture2D? ItemPanel;
    public static Texture2D? DummyIcon;
    public static Texture2D? ClickerIcon;

    public static void Load(IReadOnlyAppInfo info)
    {
        Background = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}Background.png");
        ClickPanel = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}ClickPanel.png");
        ItemPanel = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}ItemPanel.png");
        DummyIcon = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}Icons\\DummyIcon.png");
        ClickerIcon = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}Icons\\ClickerIcon.png");
    }
}