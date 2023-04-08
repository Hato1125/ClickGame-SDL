using ClickGame.Scene.Test.Model;
using ClickGame.Scene.Test.View;
using SDL2;
using SDLib;
using SDLib.Input;

namespace ClickGame.Scene.Test.Controller;

internal class PlayerController
{
    private const double SPEED = 200;

    private readonly PlayerModel _model;
    private readonly PlayerView _view;
    private bool _isMoveHorizontal = false;
    private bool _isMoveVertical = false;

    public PlayerController(PlayerModel model, PlayerView view)
    {
        _model = model;
        _view = view;
    }

    public void Update(IReadOnlyAppInfo info)
    {
        var normalize = _isMoveHorizontal && _isMoveVertical ? Math.Sqrt(2) : 1.0;
        var add = (float)((SPEED * info.DeltaTime.TotalSeconds) * normalize);

        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_D)) _model.X += add;
        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_A)) _model.X -= add;
        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_S)) _model.Y += add;
        if (Keyboard.IsPushing(SDL.SDL_Scancode.SDL_SCANCODE_W)) _model.Y -= add;
    }

    public void Render()
    {
        if (_model.Texture != null)
            _view.Render(_model.Texture, _model.X, _model.Y);
    }
}