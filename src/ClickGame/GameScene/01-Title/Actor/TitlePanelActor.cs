using System.Numerics;
using SDLib;
using SDLib.Framework;
using ClickGame.Helper;
using ClickGame.Common;

namespace ClickGame.Scenes.Title;

internal class TitlePanelActor : AppInfoActor
{
    private int _flashCounter;
    private readonly double _rotation = -18;
    private readonly byte[] _flashOpacity = new byte[]
    {
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 225, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 245, 255, 255, 255, 255, 225,
        255, 245, 255, 255, 235, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 215, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 235, 250, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 190, 255, 255, 190,
        255, 255, 255, 255, 255, 255, 245,
        255, 255, 255, 255, 255, 255, 255,
        255, 255, 255, 255, 255, 255, 255,
        215, 215, 215, 215, 215, 215, 215,
        215, 215, 215, 215, 215, 235, 255,
    };
    private Vector2[]? _panelPosition;
    private readonly Common.TextureComponent[]? _titlePanels;
    private readonly Common.TextureComponent[]? _titleGrows;

    public TitlePanelActor(Scene owner, IReadOnlyAppInfo info)
        : base(owner, info)
    {
        if (TL.TitlePanel_0 != null && TL.TitlePanel_1 != null)
        {
            _titlePanels = new Common.TextureComponent[]
            {
                new(this, info, TL.TitlePanel_0),
                new(this, info, TL.TitlePanel_1),
            };

            _panelPosition = new Vector2[]
            {
                new(PixelHelper.GetCenter(GameInfo.FirstWindowWidth,_titlePanels[0].Texture.Width) - 60,
                    PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 10)
                ),
                new(PixelHelper.GetCenter(GameInfo.FirstWindowWidth,_titlePanels[1].Texture.Width) + 60,
                    PixelHelper.GetPercent(GameInfo.FirstWindowHeight, 22)
                ),
            };
        }

        if (TL.TitlePanelGrow_0 != null && TL.TitlePanelGrow_1 != null)
        {
            _titleGrows = new Common.TextureComponent[]
            {
                new(this, info, TL.TitlePanelGrow_0),
                new(this, info, TL.TitlePanelGrow_1),
            };
        }
    }

    protected override void ActorUpdate()
    {
        if (_titleGrows != null)
        {
            _flashCounter += (int)(100 * AppInfo.DeltaTime.TotalSeconds);
            if (_flashCounter >= _flashOpacity.Length)
                _flashCounter = 0;

            for (int i = 0; i < _titleGrows.Length; i++)
            {
                if (_panelPosition != null)
                    _titleGrows[i].Position = _panelPosition[i];

                _titleGrows[i].Texture.Rotation = _rotation;
                _titleGrows[i].Texture.AlphaMod = _flashOpacity[_flashCounter];
            }
        }

        if (_titlePanels != null)
        {
            for (int i = 0; i < _titlePanels.Length; i++)
            {
                if (_panelPosition != null)
                    _titlePanels[i].Position = _panelPosition[i];

                _titlePanels[i].Texture.Rotation = _rotation;
            }
        }

        base.ActorUpdate();
    }
}