using System.Drawing;
using SDLib;
using SDLib.Graphics;
using SDLib.Framework;

namespace ClickGame;

#if DEBUG
internal class GameDebug
{
    private readonly string[] _debugText = new string[]
    {
        $"{SceneManager.SceneName}Scene ActorNum",
        $"Now Framerate",
    };
    private FontRenderer? _debugFont;

    public void Init(IReadOnlyAppInfo info)
    {
        var family = new FontFamily($"{GameInfo.FontsAsset}07やさしさゴシックボールド.ttf", 20, Color.White);
        _debugFont = new(info.RenderPtr, family);
    }

    public void Render()
    {
        if (_debugFont == null)
            return;

        for (int i = 0; i < _debugText.Length; i++)
        {
            var debugValue = i switch
            {
                0 => SceneManager.SceneActorNumber.ToString(),
                1 => $"{Program.Game.Framerate}fps",
                _ => string.Empty,
            };

            _debugFont.Text = $"{_debugText[i]}: {debugValue}";
            _debugFont.Render().Render(0, 30 * i);
        }
    }
}
#endif