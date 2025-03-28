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
    public string CardName => _cardName;
    public int Cost => _cost;
    public ActionTarget Target => _target;
    public bool SuitDependent => _suitDependent;
    public string Tooltip => _tooltip;

    [SerializeField] private MonoScript _script;    
    [SerializeField] private string _cardName;
    [Min(0)] [SerializeField] private int _cost;
    [SerializeField] private ActionTarget _target;
    [SerializeField] private bool _suitDependent;
    [SerializeField] private string _tooltip;
}
