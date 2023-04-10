namespace ClickGame.Core;

internal class RenderComponent : Component
{
    /// <summary>
    /// RenderComponentを処理化する
    /// </summary>
    /// <param name="owner">コンポーネントの持ち主</param>
    public RenderComponent(Actor owner)
        : base(owner)
    {
        owner.Scene.Renders.Add(this);
    }

    /// <summary>
    /// コンポーネントをレンダリングする
    /// </summary>
    public virtual void RednerComponent()
    {
    }
}