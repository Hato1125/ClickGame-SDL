using ClickGame.Gui;
using ClickGame.Helper;

namespace ClickGame.Scene.Title.View;

internal class MenuView
{
    public void Render(ImagePanel[] menuButton)
    {
        for(int i = 0; i < menuButton.Length; i++)
        {
            menuButton[i].X = (int)PixelHelper.GetCenter(Program.Game.Window.WindowSize.Width, menuButton[i].Width);
            menuButton[i].Y = (int)(PixelHelper.GetPercent(Program.Game.Window.WindowSize.Height, 50) + i * (menuButton[i].Height + 10));
            menuButton[i].Render();
        }
    }
}