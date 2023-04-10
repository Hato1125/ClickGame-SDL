using ClickGame.Gui;

namespace ClickGame.Core;

internal class GuiComponent : RenderComponent
{
    /// <summary>
    /// Gui
    /// </summary>
    public UIElement? GuiParts { get; set; }

    /// <summary>
    /// GuiComponentを初期化する
    /// </summary>
    /// <param name="owner">コンポーネントの持ち主</param>
    public GuiComponent(Actor owner)
        : base(owner)
    {
    }

    /// <summary>
    /// コンポーネントを更新する
    /// </summary>
    public override void UpdateComponent()
    {
        GuiParts?.Update();
        base.UpdateComponent();
    }

    /// <summary>
    /// コンポーネントをレンダリングする
    /// </summary>
    public override void RednerComponent()
    {
        GuiParts?.Render();
        base.RednerComponent();
    }
}