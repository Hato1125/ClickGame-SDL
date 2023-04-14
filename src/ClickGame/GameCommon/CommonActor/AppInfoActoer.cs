using SDLib;
using SDLib.Framework;

namespace ClickGame.Common;

internal class AppInfoActor : Actor
{
    /// <summary>
    /// アプリケーションの情報
    /// </summary>
    protected readonly IReadOnlyAppInfo AppInfo;

    /// <summary>
    /// AppInfoActorを初期化する
    /// </summary>
    /// <param name="owner">Actotの持ち主のSceneクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    public AppInfoActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner)
        => AppInfo = info;
}