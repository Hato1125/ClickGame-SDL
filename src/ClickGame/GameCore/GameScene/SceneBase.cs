using SDLib;

namespace ClickGame.Core;

internal class SceneBase
{
    /// <summary>
    /// Sceneの子要素リスト
    /// </summary>
    public readonly List<SceneBase> Children = new();

    /// <summary>
    /// Actorのリスト
    /// </summary>
    public readonly List<Actor> Actors = new();

    /// <summary>
    /// レンダリング用コンポーネントのリスト
    /// </summary>
    public readonly List<RenderComponent> Renders = new();

    /// <summary>
    /// 初期化処理を実行するか
    /// </summary>
    public bool IsInit { get; set; } = true;

    /// <summary>
    /// 初期化処理
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    public virtual void Init(IReadOnlyAppInfo info)
    {
        foreach (var child in Children)
            child.Init(info);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    public virtual void Update(IReadOnlyAppInfo info)
    {
        foreach (var actor in Actors)
            actor.UpdateActor();

        foreach (var child in Children)
            child.Update(info);
    }

    /// <summary>
    /// レンダリング処理
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    public virtual void Render(IReadOnlyAppInfo info)
    {
        foreach(var render in Renders)
            render.RednerComponent();

        foreach (var child in Children)
            child.Render(info);
    }

    /// <summary>
    /// 終了処理
    /// </summary>
    public virtual void Finish()
    {
        foreach (var child in Children)
            child.Finish();
    }
}