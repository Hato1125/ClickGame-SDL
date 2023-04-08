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
    /// シーンを登録する
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    /// <param name="scene">シーン</param>
    public static void RegistScene(string sceneName, SceneBase scene)
    {
        _sceneList.Add(sceneName, scene);

        if (NowSceneName == string.Empty)
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
            _sceneInstance.Finish();
            _sceneInstance.IsInit = true;
        }

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
    /// <param name="info"></param>
    public static void SceneView(IReadOnlyAppInfo info)
    {
        if (_sceneInstance == null)
            return;

        if (_sceneInstance.IsInit)
        {
            _sceneInstance.Init(info);
            _sceneInstance.IsInit = false;
        }
        else
        {
            _sceneInstance.Update(info);
            _sceneInstance.Render(info);
        }
    }
}