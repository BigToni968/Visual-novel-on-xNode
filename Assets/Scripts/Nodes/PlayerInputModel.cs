using UnityEngine;

public interface IModelPlayerInput
{
    public bool CloseImmediately { get; }
}

public class PlayerInputModel : XnodeModel, IModelPlayerInput
{
    [field: SerializeField] public bool CloseImmediately { get; private set; }
}