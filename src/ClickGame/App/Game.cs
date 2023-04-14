using System.Drawing;
using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Graphics;
using SDLib.Framework;

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

        SceneManager.RegistScene("Title", new ClickGame.Scenes.Title.Title(), false);
        SceneManager.RegistScene("Game", new ClickGame.Scenes.Game.Game(), false);

        SceneManager.SetScene("Title");
    }

    void Loop(IReadOnlyAppInfo info)
    {
        Keyboard.Update();
        Mouse.Update();

        SceneManager.ViewScene(info);
        if (ActorNumberFont != null)
        {
            string actorNumMessage = $"[{SceneManager.SceneName}] NowActorNum: {SceneManager.SceneActorNumber.ToString()}";
            ActorNumberFont.Text = actorNumMessage;
            ActorNumberFont.Render().Render(0, 0);
        }
    }

    void Finish(IReadOnlyAppInfo info)
    {
        SceneManager.RemoveAllScene();
    }
}