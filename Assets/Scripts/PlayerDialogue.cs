public class PlayerDialogue : IController
{
    public event ICommand.CompleteHandler Complete;

    private IModelPlayerDialog _model;
    private IViewDialoque _view;
    private VariablesLinker _variables;

    public PlayerDialogue(IModelPlayerDialog model, IViewDialoque view, VariablesLinker variables)
    {
        _view = view;
        _model = model;
        _variables = variables;
    }

    public void Execute()
    {
        _view.OnClick += OnCallBackView;
        _view.Show(_model.Name, _model.Text.Replace(_model.ReplacementSymbol, _variables.Data.PlayerName));
    }
    private void OnCallBackView()
    {
        _view.OnClick -= OnCallBackView;
        Complete?.Invoke();
    }
}
