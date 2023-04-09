using SDLib;
using SDLib.Graphics;

namespace ClickGame.Gui;

internal class ImagePanel : UIElement
{
    private const double SPEED = 1000;
    private const double DEEP = 0.2;

    private double _animeCounter;
    private double _animeValue;

    /// <summary>
    /// Texture
    /// </summary>
    protected Texture2D Texture { get; set; }

    /// <summary>
    /// ImagePanelを初期化する
    /// </summary>
    /// <param name="info">アプリケーションの情報</param>
    /// <param name="texture">テクスチャ</param>
    public ImagePanel(IReadOnlyAppInfo info, Texture2D texture)
        : base(info)
    {
        Texture = texture;
        Width = Texture.Width;
        Height = Texture.Height;

        OnUIUpdateing += AnimeUpdate;
        OnUIRendering += RenderImage;
    }

    void AnimeUpdate()
    {
        if (IsPushing())
        {
            _animeCounter += SPEED * Info.DeltaTime.TotalSeconds;

            if (_animeCounter > 90)
                _animeCounter = 90;
        }
        else
        {
            _animeCounter -= SPEED * Info.DeltaTime.TotalSeconds;

            if (_animeCounter < 0)
                _animeCounter = 0;
        }

        _animeValue = 1.0 - Math.Sin(_animeCounter * Math.PI / 180) * DEEP;

        if (TextureArea != null)
        {
            TextureArea.GetTexture().WidthScale = (float)_animeValue;
            TextureArea.GetTexture().HeightScale = (float)_animeValue;
        }
    }

    void RenderImage()
    {
        Texture.Render(0, 0);
    }
}