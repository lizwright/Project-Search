using UnityEngine;

public abstract class EnemyAction : ScriptableObject
{
    public Sprite Icon => icon;
    public string Tooltip => tooltip;
    
    [SerializeField] private Sprite icon;
    [SerializeField] private string tooltip;
    
    public abstract void DoAction();
}
