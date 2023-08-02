using UnityEngine;

public interface IModelPlayerDialog
{
    public string ReplacementSymbol { get; }
    public string Name { get; }
    public string Text { get; }
}

public class PlayerDialogModel : XnodeModel, IModelPlayerDialog
{
    [field: SerializeField] public string ReplacementSymbol { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, TextArea(5, 10)] public string Text { get; private set; }

}