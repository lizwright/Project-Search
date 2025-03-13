using UnityEngine;

public abstract class Trait : ScriptableObject, ITrait
{
    public int Priority => _priority;
    public Sprite Icon => _icon;
    
    [SerializeField] protected int _priority;
    [SerializeField] protected Sprite _icon;

    public abstract void ApplyPreChoosingEffects( DigitSequenceOptions digitOptions);
}
