using UnityEngine;
using XNode;

public interface IModelChoices
{
    public string[] Choices { get; }
    public Node[] Nodes { get; }

    public void SetEndPort(Node node);
}

public class ChoicesModel : XnodeModel, IModelChoices
{
    [Output(dynamicPortList = true)]
    [TextArea(1, 2)]
    public string[] TextChoices;
    public string[] Choices => TextChoices;
    public Node[] Nodes => GetNodes();


    private Node[] GetNodes()
    {
        Node[] result = new Node[TextChoices.Length];

        for (int i = 0; i < TextChoices.Length; i++)
            result[i] = GetPort($"{nameof(TextChoices)} {i}").Connection.node;

        return result;
    }

    public void SetEndPort(Node node)
    {
        NodePort node1 = GetOutputPort("EndPort");
        NodePort node2 = node.GetInputPort("StartPort");
        node1.ClearConnections();
        node1.Connect(node2);
    }
}