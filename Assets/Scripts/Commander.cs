using UnityEngine;
using XNode;

public class Commander : MonoBehaviour
{
    [SerializeField] private NodeGraph _graph;
    [SerializeField] private UserVariables _variables;
    [SerializeField] private DialogueView _dialogueView;
    [SerializeField] private BackgroundView _backgroundView;
    [SerializeField] private ChoicesView _choicesView;
    [SerializeField] private PortraitView _portraitView;
    [SerializeField] private PlayerInputView _playerInputView;

    private (ICommand Command, Node Node) _curent;
    private VariablesLinker _variablesLinker;
    private (ICommand, Node) Packing(Node node)
    {
        (ICommand command, Node node) result;

        result.node = node;

        result.command = node switch
        {
            IModelDialogue dialogue => new DialoguePresentar(dialogue, _dialogueView),
            IModelBackground background => new BackgroundController(background, _backgroundView),
            IModelChoices choice => new ChoicesPresentar(choice, _choicesView),
            IModelPortrait portrait => new PortraitController(portrait, _portraitView),
            IModelPlayerInput playerInput => new PlayerInput(playerInput, _playerInputView, _dialogueView, _variablesLinker),
            IModelPlayerDialog playerDialog => new PlayerDialogue(playerDialog, _dialogueView, _variablesLinker),
            _ => null
        };

        return result;
    }

    private void Next()
    {
        _curent.Command.Complete -= Next;
        NodePort port = _curent.Node.GetPort("EndPort").Connection;

        if (port == null) return;

        _curent = Packing(port.node);
        _curent.Command.Complete += Next;
        _curent.Command.Execute();

    }


    private void Start()
    {
        _variablesLinker ??= _variables.Get;
        _curent = Packing(_graph.nodes[0]);
        _curent.Command.Complete += Next;
        _curent.Command.Execute();
    }
}