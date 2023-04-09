using SDL2;
using SDLib;
using SDLib.Input;
using SDLib.Graphics;

namespace ClickGame.Gui;

internal class UIElement : IDisposable
{
    private bool _isDispose = false;
    private bool _isChildFocus = false;
    private bool _isFastCreate = true;
    private int _bufferWidth = 0;
    private int _bufferHeight = 0;
    private int _mouseX = 0;
    private int _mouseY = 0;

    /// <summary>
    /// 描画領域用のテクスチャ
    /// </summary>
    protected TextureArea? TextureArea { get; set; }

    /// <summary>
    /// アプリケーションの情報
    /// </summary>
    protected IReadOnlyAppInfo Info { get; set; }

    /// <summary>
    /// UIをレンダリングする際に呼ばれる
    /// </summary>
    protected event Action? OnUIUpdateing = delegate { };

    /// <summary>
    /// UIが更新される際に呼ばれる
    /// </summary>
    protected event Action? OnUIRendering = delegate { };

    /// <summary>
    /// UIのX座標
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// UIのY座標
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// UIの横幅
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// UIの高さ
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// UIを表示するか
    /// </summary>
    public bool IsVisible { get; set; }

    /// <summary>
    /// UIが操作を受け付けるか
    /// </summary>
    public bool IsInput { get; set; }

    /// <summary>
    /// ペイント時に呼ばれる
    /// </summary>
    public event Action? OnPaint = delegate { };

    /// <summary>
    /// ホバー時に呼ばれる
    /// </summary>
    public event Action? OnHovering = delegate { };

    /// <summary>
    /// ホバー時に押されている間呼ばれる
    /// </summary>
    public event Action? OnPushing = delegate { };

    /// <summary>
    /// ホバー時に押された瞬間のみ呼ばれる
    /// </summary>
    public event Action? OnPushed = delegate { };

    /// <summary>
    /// ホバー時に離された瞬間のみよばれる
    /// </summary>
    public event Action? OnSeparate = delegate { };

    /// <summary>
    /// キーコードリスト
    /// </summary>
    public readonly List<SDL.SDL_Scancode> KeyCode = new();

    /// <summary>
    /// 子要素リスト
    /// </summary>
    public readonly List<UIElement> Children = new();

    /// <summary>
    /// UIを初期化する
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    /// <param name="width">横幅</param>
    /// <param name="height">高さ</param>
    public UIElement(IReadOnlyAppInfo info, int width = 0, int height = 0)
    {
        if (width > 0 && height > 0)
        {
            TextureArea = new(info.RenderPtr, width, height);

            // 更新時にまた作らないようにセットする
            _bufferWidth = width;
            _bufferHeight = height;
            _isFastCreate = false;
        }

        IsVisible = true;
        IsInput = true;
        Info = info;
        Width = width;
        Height = height;
    }

    ~UIElement()
        => Dispose(false);

    /// <summary>
    /// UIを更新する 
    /// </summary>
    /// <param name="pointX">X方向の相対座標</param>
    /// <param name="pointY">Y方向の相対座標</param>
    public virtual void Update(int pointX = 0, int pointY = 0)
    {
        // サイズが変更されたら描画領域を再度作成する
        if (_isFastCreate || _bufferWidth != Width || _bufferHeight != Height)
        {
            TextureArea?.Dispose();
            TextureArea = new(Info.RenderPtr, Width, Height);

            _bufferWidth = Width;
            _bufferHeight = Height;
        }

        SDL.SDL_GetWindowPosition(Info.WindowPtr, out int x, out int y);
        if (pointX == 0 && pointY == 0)
        {
            // マウス座標は絶対座標なのでWindowの位置を引いて相対座標に変換する
            _mouseX = Mouse.X - X - x;
            _mouseY = Mouse.Y - Y - y;
        }
        else
        {
            _mouseX = pointX - X;
            _mouseY = pointY - Y;
        }

        foreach (var child in Children)
        {
            child.Update(_mouseX, _mouseY);

            // 子要素にフォーカスが当たっていたら親要素は判定しない
            _isChildFocus = child.IsHover();
        }

        CallInputEvent();
        OnUIUpdateing?.Invoke();
    }

    /// <summary>
    /// UIをレンダリングする
    /// </summary>
    /// <param name="rendererTexture">レンダラー</param>
    public virtual void Render(IntPtr? rendererTexture = null)
    {
        var render = () =>
        {
            OnUIRendering?.Invoke();
            OnPaint?.Invoke();

            foreach (var child in Children)
                child.Render(TextureArea?.GetTexture().GetTexturePtr());
        };
        TextureArea?.Render(render, rendererTexture);

        if (IsVisible)
        {
            // 拡大縮小する際に中央基準でされるように座標を調整する
            TextureArea?.GetTexture().Render(
                X + (Width - TextureArea.GetTexture().ActualWidth) / 2.0f,
                Y + (Height - TextureArea.GetTexture().ActualHeight) / 2.0f
            );
        }
    }

    /// <summary>
    /// ホバーしたかを取得する
    /// </summary>
    public bool IsHover()
        => IsInput
            && !_isChildFocus
            && _mouseX >= 0
            && _mouseY >= 0
            && _mouseX <= Width
            && _mouseY <= Height;

    /// <summary>
    /// ホバーした状態で押しているかを取得する
    /// </summary>
    public bool IsPushing()
    {
        if (!IsHover())
            return false;

        if (Mouse.IsPushing(SDL.SDL_BUTTON_LEFT))
            return true;

        foreach (var key in KeyCode)
            if (Keyboard.IsPushing(key))
                return true;

        return false;
    }

    /// <summary>
    /// ホバーした状態で押された瞬間を取得する 
    /// </summary>
    public bool IsPushed()
    {
        if (!IsHover())
            return false;

        if (Mouse.IsPushed(SDL.SDL_BUTTON_LEFT))
            return true;

        foreach (var key in KeyCode)
            if (Keyboard.IsPushed(key))
                return true;

        return false;
    }

    /// <summary>
    /// ホバーした状態で離された瞬間を取得する
    /// </summary>
    public bool IsSeparate()
    {
        if (!IsHover())
            return false;

        if (Mouse.IsSeparate(SDL.SDL_BUTTON_LEFT))
            return true;

        foreach (var key in KeyCode)
            if (Keyboard.IsSeparate(key))
                return true;

        return false;
    }

    /// <summary>
    /// UIを破棄する
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposeする
    /// </summary>
    /// <param name="isDisposing">マネージリソースを破棄するか</param>
    protected virtual void Dispose(bool isDisposing)
    {
        if (_isDispose)
            return;

        TextureArea?.Dispose();
        TextureArea = null;

        _isDispose = true;
    }

    private void CallInputEvent()
    {
        if (IsHover()) OnHovering?.Invoke();
        if (IsPushing()) OnPushing?.Invoke();
        if (IsPushed()) OnPushed?.Invoke();
        if (IsSeparate()) OnSeparate?.Invoke();
    }
}