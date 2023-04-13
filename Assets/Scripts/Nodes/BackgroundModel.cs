using UnityEngine;

public interface IModelBackground
{
    public Sprite Sprite { get; }
}

public class BackgroundModel : XnodeModel, IModelBackground
{
    [field: SerializeField]
    public Sprite Sprite { get; private set; }
}