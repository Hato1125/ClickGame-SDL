using ClickGame.Scene.Title.Model;
using ClickGame.Scene.Title.View;
using ClickGame.Scene.Title.Controller;
using ClickGame.Core;
using ClickGame.Gui;
using SDLib;

namespace ClickGame.Scene.Title;

internal class Menu : SceneBase
{
    private readonly MenuController _controller;

    public Menu(IReadOnlyAppInfo info)
    {
        var startButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\StartButton.png");
        var settingButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\SettingButton.png");
        var exitButton = Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\ExitButton.png");

        var model = new MenuModel()
        {
            MenuButtons = new ImagePanel[]
            {
                new(info, startButton),
                new(info, settingButton),
                new(info, exitButton)
            },
        };
        var view = new MenuView();

        _controller = new(model, view);
    }

    public override void Update(IReadOnlyAppInfo info)
    {
        _controller.Update();
    }

    public override void Render(IReadOnlyAppInfo info)
    {
        _controller.Render();
    }
}