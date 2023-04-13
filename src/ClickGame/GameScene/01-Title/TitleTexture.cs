using SDLib;
using SDLib.Graphics;

namespace ClickGame.Scenes.Title;

internal static class TL
{
    private static readonly string TitleGraphics = $"{GameInfo.GraphicsAsset}01-Title\\";

    public static Texture2D? StartButton;
    public static Texture2D? SettingButton;
    public static Texture2D? ExitButton;
    public static Texture2D? Logo;
    public static Texture2D? Background;

    public static void Load(IReadOnlyAppInfo info)
    {
        StartButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}StartButton.png");
        SettingButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}SettingButton.png");
        ExitButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}ExitButton.png");
        Logo = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}Logo.png");
        Background = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}Background.png");
    }
}