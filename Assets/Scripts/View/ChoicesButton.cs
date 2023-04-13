using UnityEngine.UI;
using UnityEngine;
using TMPro;
using XNode;

public interface IChoiceButton
{
    public Button Button { get; }
    public TextMeshProUGUI Text { get; }
    public Node Node { get; set; }
}

public class ChoicesButton : MonoBehaviour, IChoiceButton
{
    [field: SerializeField]
    public Button Button { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI Text { get; private set; }

    public Node Node { get; set; }
}