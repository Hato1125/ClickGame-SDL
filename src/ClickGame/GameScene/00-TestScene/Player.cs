using ClickGame.Scene.Test.Model;
using ClickGame.Scene.Test.View;
using ClickGame.Scene.Test.Controller;
using ClickGame.Core;
using SDLib;
using SDLib.Graphics;

namespace ClickGame.Scene.Test;

internal class Player : SceneBase
{
    private readonly Texture2D _playerTexture;
    private readonly PlayerController _controller;

    public Player(IReadOnlyAppInfo info)
    {
        _playerTexture = Test.TextureManager.LoadTexture(info.RenderPtr, $"{GameInfo.GraphicsAsset}00-Test\\Test.png");
        _controller = new(
            new PlayerModel() { Texture = _playerTexture },
            new PlayerView()
        );
    }

    public override void Update(IReadOnlyAppInfo info)
    {
        _controller.Update(info);
    }

    public override void Render(IReadOnlyAppInfo info)
    {
        _controller.Render();
    }
}