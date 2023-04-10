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
    /// 現在のActorのステート
    /// </summary>
    public ActorState State { get; set; }

    /// <summary>
    /// Actorの初期化を行う
    /// </summary>
    /// <param name="scene">追加するシーンのインスタンス</param>
    public Actor(SceneBase scene)
    {
        Scene = scene;
        scene.AddActor(this);
    }

    /// <summary>
    /// Actorを更新する
    /// </summary>
    public void Update()
    {
        if(State == ActorState.Active)
            UpdateActor();
    }

    /// <summary>
    /// Actorを更新する
    /// </summary>
    protected virtual void UpdateActor()
    {
        foreach(var component in Components)
            component.UpdateComponent();
    }

    /// <summary>
    /// Actorの状態の列挙型
    /// </summary>
    public enum ActorState
    {
        Active,
        Dead,
    }
}