namespace ClickGame.Core;

internal class Actor
{
    /// <summary>
    /// シーンクラス
    /// </summary>
    public readonly SceneBase Scene;

    /// <summary>
    /// コンポーネントのリスト
    /// </summary>
    public readonly List<Component> Components = new();

    /// <summary>
    /// Actorの初期化を行う
    /// </summary>
    /// <param name="scene">追加するシーンのインスタンス</param>
    public Actor(SceneBase scene)
    {
        Scene = scene;
        scene.Actors.Add(this);
    }

    /// <summary>
    /// Actorを更新する
    /// </summary>
    public virtual void UpdateActor()
    {
        foreach(var component in Components)
            component.UpdateComponent();
    }
}