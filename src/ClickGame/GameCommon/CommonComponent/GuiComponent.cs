using SDLib;
using SDLib.Framework;
using ClickGame.Gui;

namespace ClickGame.Common;

internal class GuiComponent : AppInfoComponent
{
    public readonly UIElement Gui;

    public GuiComponent(Actor owner, IReadOnlyAppInfo info, UIElement gui)
        : base(owner, info)
        => Gui = gui;

    protected override void ComponentUpdate()
    {
        Gui.Update();

        base.ComponentUpdate();
    }

    protected override void ComponentRender()
    {
        Gui.Render();

        base.ComponentRender();
    }
}