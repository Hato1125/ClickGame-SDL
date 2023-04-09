using ClickGame.Scene.Title.Model;
using ClickGame.Scene.Title.View;

namespace ClickGame.Scene.Title.Controller;

internal class MenuController
{
    private MenuModel _model;
    private MenuView _view;

    public MenuController(MenuModel model, MenuView view)
    {
        _model = model;
        _view = view;
    }

    public void Update()
    {
        if(_model.MenuButtons == null)
            return;

        for(int i = 0; i < _model.MenuButtons.Length; i++)
        {
            _model.MenuButtons[i].Update();

            if(_model.MenuButtons[i].IsSeparate())
            {
                foreach(var button in _model.MenuButtons)
                    button.IsInput = false;
            }
        }
    }

    public void Render()
    {
        if(_model.MenuButtons == null)
            return;

        _view.Render(_model.MenuButtons);
    }
}