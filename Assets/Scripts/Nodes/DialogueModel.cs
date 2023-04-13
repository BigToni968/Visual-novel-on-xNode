using UnityEngine;
using XNode;

public interface IModelDialogue
{
    public string Name { get; }
    public string Text { get; }
}

public class XnodeModel : Node
{
    [Input]
    public bool StartPort;

    [Output]
    public bool EndPort;
}

public class DialogueModel : XnodeModel, IModelDialogue
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    [field: TextArea(5, 10)]
    public string Text { get; private set; }

}