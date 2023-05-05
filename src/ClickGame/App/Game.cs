using System.Drawing;
using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame;

internal class Game : App
{
    private readonly GameDebug _debug = new();

    public static readonly GameSetting Setting = new($"{AppContext.BaseDirectory}Setting.json");

    public Game(
        string windowTitle,
        SDL.SDL_WindowFlags windowFlags,
        SDL.SDL_RendererFlags rendererFlags,
        Size windowSize,
        Point? windowPosition = null,
        Size? windowMinSize = null,
        Size? windowMaxSize = null)
        : base(
            windowTitle,
            windowFlags,
            rendererFlags,
            windowSize,
            windowPosition,
            windowMinSize,
            windowMaxSize
        )
    {
        SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "2");

        MaxFramerate = 45;
        OnInitialize += Init;
        OnMainLoop += Loop;
        OnFinish += Finish;
    }

    void Init(IReadOnlyAppInfo info)
    {
        _debug.Init(info);

        SceneManager.RegistScene("Test", new Scenes.Test.Test(), false);
        SceneManager.RegistScene("Title", new Scenes.Title.Title(), false);
        SceneManager.RegistScene("Game", new Scenes.Game.Game(), false);

        SceneManager.SetScene("Title");
    }

    void Loop(IReadOnlyAppInfo info)
    {
        Keyboard.Update();
        Mouse.Update();

        SceneManager.ViewScene(info);

        _debug.Render();
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}