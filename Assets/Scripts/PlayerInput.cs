public interface IPresentarPlayerInput : IPresentar { }

public class PlayerInput : IPresentarPlayerInput
{
    public event ICommand.CompleteHandler Complete;

    private IViewDialoque _viewDialoque;
    private IViewPlayerInput _view;
    private IModelPlayerInput _model;
    private VariablesLinker _variables;

    public PlayerInput(IModelPlayerInput model, IViewPlayerInput view, IViewDialoque viewDialoque, VariablesLinker variables)
    {
        _view = view;
        _viewDialoque = viewDialoque;
        _model = model;
        _variables = variables;
    }

    public void Execute()
    {
        _viewDialoque.Hide();
        _view.Show();
        _view.Callback += PlayerInputProcessing;
    }

    private void PlayerInputProcessing(string input, PlayerInputButtonType button)
    {
        switch (button)
        {
            case PlayerInputButtonType.Clear:
                _view.InputField.text = null;
                break;
            case PlayerInputButtonType.Save:
                _variables.Data.PlayerName = input;
                if (_model.CloseImmediately)
                    _view.Hide();

                _view.Callback -= PlayerInputProcessing;

                Complete?.Invoke();
                break;
        }

    }
}