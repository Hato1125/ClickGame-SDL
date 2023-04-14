using SDLib;
using SDLib.Framework;

namespace ClickGame.Common;

internal class AppInfoComponent : Component
{
    /// <summary>
    /// アプリケーションの情報
    /// </summary>
    protected readonly IReadOnlyAppInfo AppInfo;

    /// <summary>
    /// AppInfoComponentを初期化する
    /// </summary>
    /// <param name="owner">Componentの持ち主のActorクラス</param>
    /// <param name="info">アプリケーションの情報</param>
    public AppInfoComponent(Actor owner, IReadOnlyAppInfo info)
        : base(owner)
        => AppInfo = info;
}