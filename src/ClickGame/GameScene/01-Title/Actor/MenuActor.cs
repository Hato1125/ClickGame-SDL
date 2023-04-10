using SDLib;
using SDLib.Graphics;
using ClickGame.Core;
using ClickGame.Helper;

namespace ClickGame.Scene.Title;

internal class MenuActor : Actor
{
    public MenuActor(SceneBase scene, IReadOnlyAppInfo info)
        : base(scene)
    {
        var textures = new Texture2D[]
        {
            Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\StartButton.png"),
            Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\SettingButton.png"),
            Title.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}01-Title\\ExitButton.png"),
        };

        MenuComponent? tempComponent = null;
        for (int i = 0; i < textures.Length; i++)
        {
            tempComponent = new MenuComponent(this, info, textures[i]);

            var gui = tempComponent.GuiParts;
            if (gui != null)
            {
                gui.X = (int)PixelHelper.GetCenter(GameInfo.FirstWindowWidth,gui.Width);
                gui.Y = (int)PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 50) + (gui.Height + 10) * i;

                gui.OnSeparate += () =>
                {
                    SetGuiInput(false);
                };
            }
        }
    }

    void SetGuiInput(bool isInput)
    {
        foreach(var component in Components)
        {
            if(component is MenuComponent)
            {
                var menu = (MenuComponent)component;

                if(menu.GuiParts != null)
                    menu.GuiParts.IsInput = isInput;
            }
        }
    }
}