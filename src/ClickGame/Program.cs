using SDL2;

namespace ClickGame;

internal class Program
{
    public static readonly Game Game = new(
            $"{GameInfo.AppName} {GameInfo.AppVer}",
            SDL.SDL_WindowFlags.SDL_WINDOW_ALLOW_HIGHDPI | SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN,
            SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC,
            new(GameInfo.FirstWindowWidth, GameInfo.FirstWindowHeight)
        );

    [STAThread]
    private static void Main()
    {
        Game.Run();
    }
}