using SDLib;
using SDLib.Graphics;

namespace ClickGame.Scenes.Game;

internal static class TL
{
    private static readonly string GameGraphics = $"{GameInfo.GraphicsAsset}02-Game\\";

    public static Texture2D? Background;
    public static Texture2D? ClickPanel;

    public static void Load(IReadOnlyAppInfo info)
    {
        Background = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}Background.png");
        ClickPanel = Game.TextureManager.LoadTexture(info.RenderPtr, $"{GameGraphics}ClickPanel.png");
    }
}