public interface ICommand
{
    public delegate void CompleteHandler();
    public event CompleteHandler Complete;

    public void Execute();
}

public interface IPresentar : ICommand { }

public class DialoguePresentar : IPresentar
{
    public event ICommand.CompleteHandler Complete;

    private IModelDialogue _model;
    private IViewDialoque _view;

    public DialoguePresentar(IModelDialogue model, IViewDialoque view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        _view.OnClick += OnCallBackView;
        _view.Show(_model.Name, _model.Text);
    }

    private void OnCallBackView()
    {
        _view.OnClick -= OnCallBackView;
        Complete?.Invoke();
    }
}