using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelData _level;
    [SerializeField] private TurnManager _turnManager;
    [SerializeField] private EncounterManager _encounterManager;
    
    private void Start()
    {
        _turnManager.EnterOutOfCombat();
        _encounterManager.SetLevel(_level);
        
        StartNextEncounter();
    }

    public void StartNextEncounter()
    {
        if (_encounterManager.LevelHasNextEncounter() == false)
        {
            Debug.Log("LEVEL COMPLETE !");
            return;
        }

        _encounterManager.SpawnNextEncounter();
        
        _turnManager.StartPlayerTurn();

    }
}
