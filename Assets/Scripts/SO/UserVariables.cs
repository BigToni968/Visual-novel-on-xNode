using UnityEngine;

[CreateAssetMenu(menuName = "Game/Data/User variables")]
public class UserVariables : ScriptableObject
{
    [SerializeField] private VariablesLinker _variables;

    public VariablesLinker Get => new VariablesLinker(_variables.Data);
}

[System.Serializable]
public class VariablesLinker
{
    [SerializeField] public Variables Data;

    public VariablesLinker(Variables data)
    {
        Data = data;
    }
}

[System.Serializable]
public struct Variables
{
    public string PlayerName;
}