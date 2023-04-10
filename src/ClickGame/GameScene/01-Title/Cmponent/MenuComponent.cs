using SDLib;
using SDLib.Graphics;
using ClickGame.Core;
using ClickGame.Gui;

namespace ClickGame.Scene.Title;

internal class MenuComponent : GuiComponent
{
    public MenuComponent(Actor owner, IReadOnlyAppInfo info, Texture2D image)
        : base(owner)
    {
        GuiParts = new ImagePanel(info, image);
    }
}