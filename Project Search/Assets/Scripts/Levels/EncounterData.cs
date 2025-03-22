using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Encounter", menuName = "ScriptableObjects/Encounter")]
public class EncounterData : ScriptableObject
{
    public List<EnemyData> EnemyData => _enemyData;
    
    [SerializeField] private List<EnemyData> _enemyData;
}
