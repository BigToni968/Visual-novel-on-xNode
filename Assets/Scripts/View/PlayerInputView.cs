using UnityEngine;
using System;
using TMPro;

public enum PlayerInputButtonType
{
    Save,
    Clear
}

public interface IViewPlayerInput
{
    public event Action<string, PlayerInputButtonType> Callback;
    public TMP_InputField InputField { get; }

    public void Show();
    public void Hide();
}

public class PlayerInputView : MonoBehaviour, IViewPlayerInput
{
    [field: SerializeField] public TMP_InputField InputField { get; private set; }
    [SerializeField] private Canvas _canvas;

    public event Action<string, PlayerInputButtonType> Callback;

    public void Show() => _canvas.enabled = true;
    public void Hide() => _canvas.enabled = false;

    public void OnButtonAction(int index) => Callback?.Invoke(InputField.text, (PlayerInputButtonType)index);

}
