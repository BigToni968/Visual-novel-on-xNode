public interface IController : ICommand { }

public class BackgroundController : IController
{
    public event ICommand.CompleteHandler Complete;
    private IViewBackground _view;
    private IModelBackground _model;

    public BackgroundController(IModelBackground model, IViewBackground view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        _view.Replace(_model.Sprite);
        Complete?.Invoke();
    }
}