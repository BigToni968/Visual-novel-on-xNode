public class PortraitController : IController
{
    public event ICommand.CompleteHandler Complete;

    private IModelPortrait _model;
    private IViewPortrait _view;

    public PortraitController(IModelPortrait model, IViewPortrait view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        _view.Show(_model.Name, _model.Sprite, _model.Position);
        Complete?.Invoke();
    }
}
