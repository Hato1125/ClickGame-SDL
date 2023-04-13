using System.Drawing;
using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Graphics;
using SDLib.Framework;
using ClickGame.Scenes.Title;

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
        var font = new FontFamily($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf", 20, Color.White);
        ActorNumberFont = new(info.RenderPtr, font);

        SceneManager.RegistScene("Title", new Title());
    }

    void Loop(IReadOnlyAppInfo info)
    {
        Keyboard.Update();
        Mouse.Update();

        SceneManager.ViewScene(info);
        if (ActorNumberFont != null)
        {
            ActorNumberFont.Text = $"ActorNumber: {SceneManager.SceneActorNumber.ToString()}";
            ActorNumberFont.Render().Render(0, 0);
        }
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}