using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard_ActionCard", menuName = "ScriptableObjects/Action Card/ New Action Card")]
public class ActionCardData : ScriptableObject
{
    public enum ActionTarget
    {
        Enemy
    }

    public MonoScript Script => _script;
    public int Cost => _cost;
    public ActionTarget Target => _target;

    [SerializeField] private MonoScript _script;
    [Min(0)] [SerializeField] private int _cost;
    [SerializeField] private ActionTarget _target;
}
