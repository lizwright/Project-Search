using System.Collections.Generic;
using UnityEngine;

public abstract class Trait : ScriptableObject, ITrait
{
    public int Priority => _priority;
    
    [SerializeField] protected int _priority;

    public abstract void ApplyPreChoosingEffects(ref List<Resource.Suit>[] digitOptions);
}
