using SDLib.Framework;
using ClickGame.Gui;

namespace ClickGame.Scenes.Title;

internal class MenuComponent : Component
{
    public ImagePanel? Gui { get; set; }

    public MenuComponent(Actor owner)
        : base(owner)
    {
    }

    protected override void ComponentUpdate()
    {
        Gui?.Update();

        base.ComponentUpdate();
    }

    protected override void ComponentRender()
    {
        Gui?.Render();

        base.ComponentRender();
    }

    protected override void ComponentDispose(bool isDisposeing)
    {
        base.ComponentDispose(isDisposeing);

        Gui?.Dispose();
    }
}