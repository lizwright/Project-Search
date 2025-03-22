using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level")]
public class LevelData : ScriptableObject
{
    public List<EncounterData> Encounters => _encounters;
    
    [SerializeField] private List<EncounterData> _encounters;
}
