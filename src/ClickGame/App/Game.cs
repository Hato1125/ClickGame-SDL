using System.Drawing;
using SDL2;
using SDLib;
using ClickGame.Core;
using ClickGame.Scene.Test;

namespace ClickGame;

internal class Game : App
{
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
        OnInitialize += Init;
        OnMainLoop += Loop;
        OnFinish += Finish;
    }

    void Init(IReadOnlyAppInfo info)
    {
        SceneManager.RegistScene("Test", new Test(info));
    }
    
    void Loop(IReadOnlyAppInfo info)
    {
        SceneManager.SceneView(info);
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}