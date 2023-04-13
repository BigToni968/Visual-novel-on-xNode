using UnityEngine;

public enum Position
{
    Center,
    Left,
    Right
}

public interface IModelPortrait
{
    public string Name { get; }
    public Sprite Sprite { get; }
    public Position Position { get; }
}

public class PortraitModel : XnodeModel, IModelPortrait
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public Sprite Sprite { get; private set; }

    [field: SerializeField]
    public Position Position { get; private set; }
}