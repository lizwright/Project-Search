using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public Sprite Icon => icon;
    
    [SerializeField] private Sprite icon;
    
    public abstract void DoAction();
}
