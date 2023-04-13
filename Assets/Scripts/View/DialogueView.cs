using UnityEngine;
using TMPro;

public interface IViewDialoque
{
    public delegate void ViewDialoqueHandler();
    public event ViewDialoqueHandler OnClick;
    public void Show(string name, string text);
    public void OnCallBack();
    public void Hide();
}

public class DialogueView : MonoBehaviour, IViewDialoque
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _text;

    public event IViewDialoque.ViewDialoqueHandler OnClick;

    public void Show(string name, string text)
    {
        _name.SetText(name);
        _text.SetText(text);
        _canvas.gameObject.SetActive(true);
    }

    public void OnCallBack()
    {
        OnClick?.Invoke();
    }

    public void Hide()
    {
        _canvas.gameObject.SetActive(false);
    }

}