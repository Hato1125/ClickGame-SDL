namespace ClickGame;

internal static class GameInfo
{
    public static readonly string AppName = "ClickGame";
    public static readonly string AppVer = "0.0.0";
    public static readonly string AssetPath = $"{AppContext.BaseDirectory}Assets\\";
    public static readonly string GraphicsAsset = $"{AssetPath}Graphics\\";
    public static readonly string SoundsAsset = $"{AssetPath}Sounds\\";
    public static readonly string FontsAsset = $"{AssetPath}Fonts\\";
    public static readonly int FirstWindowWidth = 1280;
    public static readonly int FirstWindowHeight = 720;
}