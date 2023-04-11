using SDLib;

namespace ClickGame.Core;

internal static class SceneManager
{
    private static readonly Dictionary<string, SceneBase> _sceneList = new();
    private static SceneBase? _sceneInstance = null;

    /// <summary>
    /// 現在のシーンの名前
    /// </summary>
    public static string NowSceneName { get; private set; } = string.Empty;

    /// <summary>
    /// 現在アップデート中かを取得する
    /// </summary>
    public static bool IsUpdating { get; private set; }

    /// <summary>
    /// 現在のシーンのActorの数
    /// </summary>
    public static int NowSceneActorNum { get; private set; }

    /// <summary>
    /// シーンを登録する
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    /// <param name="scene">シーン</param>
    public static void RegistScene(string sceneName, SceneBase scene, bool isFastSceneAdd = true)
    {
        Console.WriteLine($"[ SYSTEM::SCENE ] Regist {sceneName} Scene.");
        _sceneList.Add(sceneName, scene);

        if (isFastSceneAdd && NowSceneName == string.Empty)
            SetScene(sceneName);
    }

    /// <summary>
    /// シーンをセットする
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public static void SetScene(string sceneName)
    {
        if (_sceneInstance != null)
        {
            Console.WriteLine($"[ SYSTEM::SCENE ] Finish {NowSceneName} Scene.");
            _sceneInstance.Finish();
            _sceneInstance.IsInit = true;
        }

        Console.WriteLine($"[ SYSTEM::SCENE ] Set {sceneName} Scene.");
        NowSceneName = sceneName;
        _sceneInstance = _sceneList[sceneName];
    }

    /// <summary>
    /// 登録されたシーンを削除する
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public static void RemoveScene(string sceneName)
    {
        var removeScene = _sceneList[sceneName];

        if (_sceneInstance == removeScene)
        {
            _sceneInstance.Finish();
            _sceneInstance = null;
            NowSceneName = string.Empty;
        }

        _sceneList.Remove(sceneName);
    }

    /// <summary>
    /// 登録されたシーンをすべて削除する
    /// </summary>
    public static void RemoveAllScene()
    {
        _sceneInstance = null;
        NowSceneName = string.Empty;

        foreach (var scene in _sceneList)
            scene.Value.Finish();

        _sceneList.Clear();
    }

    /// <summary>
    /// シーンを表示する
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    public static void SceneView(IReadOnlyAppInfo info)
    {
        if (_sceneInstance == null)
            return;

        NowSceneActorNum = _sceneInstance.Actors.Count;
        if (_sceneInstance.IsInit)
        {
            Console.WriteLine($"[ SYSTEM::SCENE ] Init {NowSceneName} Scene.");
            _sceneInstance.Init(info);
            _sceneInstance.IsInit = false;
        }
        else
        {
            IsUpdating = true;
            _sceneInstance.Update(info);
            IsUpdating = false;

            _sceneInstance.Render(info);
        }

        // 追加を延期したActorを追加する
        if (_sceneInstance.PendingActor.Count < 0)
        {
            Console.WriteLine("[ SYSTEM::SCENE ] Add PendingActor now.");

            foreach (var actor in _sceneInstance.PendingActor)
                _sceneInstance.AddActor(actor);

            _sceneInstance.PendingActor.Clear();
        }

        // Dead状態のActorを削除する
        foreach (var actor in _sceneInstance.Actors)
        {
            if (actor.State == Actor.ActorState.Dead)
            {
                _sceneInstance.RemoveActor(actor);
                Console.WriteLine("[ SYSTEM::SCENE ] Delete Actor.");
            }
        }
    }
}