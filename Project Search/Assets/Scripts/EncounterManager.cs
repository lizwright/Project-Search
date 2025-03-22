using System;
using System.Collections.Generic;
using UnityEngine;

public class EncounterManager : MonoBehaviour
{
    public static event Action<int> EncounterChanged;
    
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private EnemySpawner _enemySpawner;

    private List<Enemy> _aliveEnemies;
    private LevelData _level;
    private int _encounterIndex;


    public void SetLevel(LevelData level)
    {
        _level = level;
    }

    public bool LevelHasNextEncounter()
    {
        return _encounterIndex < _level.Encounters.Count;
    }
    
    public void SpawnNextEncounter()
    {
        EncounterData encounterData = _level.Encounters[_encounterIndex];
        _aliveEnemies = new List<Enemy>(_enemySpawner.SpawnEnemies(encounterData.EnemyData));
        EncounterChanged?.Invoke(_encounterIndex);
        _encounterIndex++;
    }

    private void OnEnable()
    {
        Enemy.EnemyDied += RemoveEnemyFromAliveList;
    }
    
    private void OnDisable()
    {
        Enemy.EnemyDied -= RemoveEnemyFromAliveList;
    }

    private void RemoveEnemyFromAliveList(Enemy enemy)
    {
        _aliveEnemies.Remove(enemy);

        if (_aliveEnemies.Count == 0)
        {
            _gameManager.StartNextEncounter();
        }
    }
    
}
