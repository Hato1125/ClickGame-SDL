using System.Drawing;
using SDL2;
using SDLib;
using SDLib.Input;
using ClickGame.Core;
using ClickGame.Scene.Test;
using ClickGame.Scene.Title;

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
        SDL.SDL_SetHint(SDL.SDL_HINT_RENDER_SCALE_QUALITY, "1");

        OnInitialize += Init;
        OnMainLoop += Loop;
        OnFinish += Finish;
    }

    void Init(IReadOnlyAppInfo info)
    {
        SceneManager.RegistScene("Test", new Test(info));
        SceneManager.RegistScene("Title", new Title(info));

        SceneManager.SetScene("Title");
    }

    void Loop(IReadOnlyAppInfo info)
    {
        Keyboard.Update();
        Mouse.Update();

        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_F1)
            && Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_T))
            SceneManager.SetScene("Test");

        SceneManager.SceneView(info);
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}