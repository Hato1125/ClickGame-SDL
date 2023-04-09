using ClickGame.Core;
using ClickGame.Gui;
using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Resource;

namespace ClickGame.Scene.Test;

internal class Test : SceneBase
{
    private ImagePanel parentElement;

    public static readonly TextureManager TextureManager = new();

    public Test(IReadOnlyAppInfo info)
    {
        var rectangle = new SDL.SDL_Rect() { x = 0, y = 0, w = 200, h = 200 };
        var texture = Test.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}00-Test\\Test.png");

        parentElement = new(info, texture);
        parentElement.X = 100;
        parentElement.Y = 100;

        Children.Add(new Player(info));
    }

    public override void Init(IReadOnlyAppInfo info)
    {
        base.Init(info);
    }

    public override void Update(IReadOnlyAppInfo info)
    {
        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_F1)
            && Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_B))
            SceneManager.SetScene("Title");

        parentElement.Update();

        base.Update(info);
    }

    public override void Render(IReadOnlyAppInfo info)
    {
        parentElement.Render();

        base.Render(info);
    }

    public override void Finish()
    {
        base.Finish();
    }
}