using UnityEngine;

[CreateAssetMenu(fileName = "NewCard_ActionCard", menuName = "ScriptableObjects/Action Card/ New Action Card")]
public class ActionCardData : ScriptableObject
{
    public int Cost => _cost;
    [Min(0)]
    [SerializeField] private int _cost;
}
