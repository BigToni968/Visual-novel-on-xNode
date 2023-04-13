using UnityEngine.UI;
using UnityEngine;

public interface IViewBackground
{
    public void Replace(Sprite sprite);
}

public class BackgroundView : MonoBehaviour, IViewBackground
{
    [SerializeField] private Image _image;

    public void Replace(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}