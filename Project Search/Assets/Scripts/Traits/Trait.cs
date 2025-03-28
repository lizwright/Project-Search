using UnityEngine;

public abstract class Trait : ScriptableObject, ITrait
{
    public int Priority => _priority;
    public Sprite Icon => _icon;
    public string Tooltip => _tooltip;
    
    [SerializeField] protected int _priority;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected string _tooltip;

    public abstract void ApplyPreChoosingEffects( DigitSequenceOptions digitOptions);
}
