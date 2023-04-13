using XNode;

public interface IPresentarChoice : IPresentar
{
    public void OnCallBackView(Node node);
}

public class ChoicesPresentar : IPresentarChoice
{
    public event ICommand.CompleteHandler Complete;

    private IViewChoices _view;
    private IModelChoices _model;

    public ChoicesPresentar(IModelChoices model, IViewChoices view)
    {
        _model = model;
        _view = view;
    }

    public void Execute()
    {
        _view.ChoiceCallback += OnCallBackView;
        _view.Show(_model.Choices, _model.Nodes);
    }

    public void OnCallBackView(Node node)
    {
        _model.SetEndPort(node);
        _view.ChoiceCallback -= OnCallBackView;
        Complete?.Invoke();
    }

    public void OnCallBackView() { }
}
