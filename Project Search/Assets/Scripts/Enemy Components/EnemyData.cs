using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy_EnemyData", menuName = "ScriptableObjects/Enemy/Data/New Enemy")]
public class EnemyData : ScriptableObject
{
    public List<Trait> Traits => _traits;
    public EnemyAction[] Actions => _actions;
    public int DigitSlotsCountCount => _digitSlotsCount;
    
    [SerializeField] private List<Trait> _traits;
    [SerializeField] private EnemyAction[] _actions;
    [SerializeField] private int _digitSlotsCount;

}
