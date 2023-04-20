using SDLib;
using SDLib.Graphics;

namespace ClickGame.Scenes.Title;

internal static class TL
{
    private static readonly string TitleGraphics = $"{GameInfo.GraphicsAsset}01-Title\\";

    public static Texture2D? StartButton;
    public static Texture2D? SettingButton;
    public static Texture2D? ExitButton;
    public static Texture2D? TitlePanel_0;
    public static Texture2D? TitlePanelGrow_0;
    public static Texture2D? TitlePanel_1;
    public static Texture2D? TitlePanelGrow_1;
    public static Texture2D? Background;

    public static void Load(IReadOnlyAppInfo info)
    {
        StartButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}StartButton.png");
        SettingButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}SettingButton.png");
        ExitButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}ExitButton.png");
        TitlePanel_0 = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}TitlePanel\\TitlePanel_0.png");
        TitlePanelGrow_0 = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}TitlePanel\\TitlePanelGrow_0.png");
        TitlePanel_1 = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}TitlePanel\\TitlePanel_1.png");
        TitlePanelGrow_1 = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}TitlePanel\\TitlePanelGrow_1.png");
        Background = Title.TextureManager.LoadTexture(info.RenderPtr, $"{TitleGraphics}Background.png");
    }
}