namespace ClickGame.Core;

internal class Component
{
    /// <summary>
    /// コンポーネントの持ち主のActor
    /// </summary>
    protected readonly Actor OwnerActor;

    /// <summary>
    /// コンポーネントの初期化
    /// </summary>
    /// <param name="owner">コンポーネントの持ち主</param>
    public Component(Actor owner)
    {
        OwnerActor = owner;
        owner.Components.Add(this);
    }

    /// <summary>
    /// コンポーネントの更新
    /// </summary>
    public virtual void UpdateComponent()
    {
    }
}