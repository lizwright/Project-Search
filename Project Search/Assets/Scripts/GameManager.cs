using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelData _level;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private TurnManager _turnManager;

    private int _encounterIndex;

    private void Start()
    {
        _turnManager.EnterOutOfCombat();
        
        SpawnNextEncounter();
        
        _turnManager.StartPlayerTurn();
    }

    private void SpawnNextEncounter()
    {
        EncounterData encounter = _level.Encounters[_encounterIndex];
        _enemySpawner.SpawnEnemies(encounter.EnemyData);
        _encounterIndex++;
    }
}
