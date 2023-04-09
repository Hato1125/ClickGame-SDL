using ClickGame.Core;
using ClickGame.Gui;
using SDL2;
using SDLib;
using SDLib.Graphics;
using SDLib.Resource;

namespace ClickGame.Scene.Test;

internal class Test : SceneBase
{
    private ImagePanel parentElement;
    private UIElement childElement;

    public static readonly TextureManager TextureManager = new();

    public Test(IReadOnlyAppInfo info)
    {
        var rectangle = new SDL.SDL_Rect() { x = 0, y = 0, w = 200, h = 200 };
        var texture = Test.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}00-Test\\Test.png");

        parentElement = new(info, texture);
        parentElement.X = 100;
        parentElement.Y = 100;

        /*
        parentElement = new(info, 200, 200);
        parentElement.X = 300;
        parentElement.Y = 300;
        parentElement.OnPaint += () =>
        {
            SDL.SDL_GetRenderDrawColor(info.RenderPtr, out byte r, out byte g, out byte b, out byte a);
            SDL.SDL_SetRenderDrawColor(info.RenderPtr, 255, 0, 0, 255);
            SDL.SDL_RenderFillRect(info.RenderPtr, ref rectangle);
            SDL.SDL_SetRenderDrawColor(info.RenderPtr, r, g, b, a);
        };

        childElement = new(info, 100, 100);
        childElement.X = 10;
        childElement.Y = 10;
        childElement.OnPaint += () =>
        {
            SDL.SDL_GetRenderDrawColor(info.RenderPtr, out byte r, out byte g, out byte b, out byte a);
            SDL.SDL_SetRenderDrawColor(info.RenderPtr, 0, 0, 255, 255);
            SDL.SDL_RenderFillRect(info.RenderPtr, ref rectangle);
            SDL.SDL_SetRenderDrawColor(info.RenderPtr, r, g, b, a);
        };

        parentElement.Children.Add(childElement);
        */

        Children.Add(new Player(info));
    }

    public override void Init(IReadOnlyAppInfo info)
    {
        base.Init(info);
    }

    public override void Update(IReadOnlyAppInfo info)
    {
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
        TextureManager.DeleteAllTexture();

        base.Finish();
    }
}