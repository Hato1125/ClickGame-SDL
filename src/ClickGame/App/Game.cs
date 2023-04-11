using System.Drawing;
using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Graphics;
using ClickGame.Core;
using ClickGame.Scene.Test;
using ClickGame.Scene.Title;

namespace ClickGame;

internal class Game : App
{
    private FontRenderer? ActorNumberFont;

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

        MaxFramerate = 60;
        OnInitialize += Init;
        OnMainLoop += Loop;
        OnFinish += Finish;
    }

    void Init(IReadOnlyAppInfo info)
    {
        Console.WriteLine($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf");
        Console.WriteLine(@"C:\Users\hatof\Desktop\ClickGame\build\Debug\net7.0\Assets\Fonts\07やさしさゴシックボールド.ttf");
        var font = new FontFamily($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf", 30, Color.White);
        ActorNumberFont = new(info.RenderPtr, font);

        SceneManager.RegistScene("Test", new Test(info), false);
        SceneManager.RegistScene("Title", new Title(info), false);

        SceneManager.SetScene("Title");
    }

    void Loop(IReadOnlyAppInfo info)
    {
        Keyboard.Update();
        Mouse.Update();

        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_F1)
            && Keyboard.IsPushed(SDL.SDL_Scancode.SDL_SCANCODE_T))
            SceneManager.SetScene("Test");

        SceneManager.SceneView(info);

        if (ActorNumberFont != null)
        {
            ActorNumberFont.Text = SceneManager.NowSceneActorNum.ToString();
            ActorNumberFont.Render().Render(0, 0);
        }
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}