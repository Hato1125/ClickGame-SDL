using ClickGame.Gui;

namespace ClickGame.Scene.Title.Model;

internal class MenuModel
{
    /// <summary>
    /// 遷移するシーンの名前
    /// </summary>
    public readonly string[] Transition = new string[] { "Game", "Setting", "Exit" };

    /// <summary>
    /// ボタンのテクスチャ
    /// </summary>
    public ImagePanel[]? MenuButtons;
}