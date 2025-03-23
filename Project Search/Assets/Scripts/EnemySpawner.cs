using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private CenterHorizontalLayout _enemyHolder;
    
    public Enemy[] SpawnEnemies(List<EnemyData> enemyData)
    {
        _enemyHolder.RemoveChildren(transform);

        Enemy[] enemies = new Enemy[enemyData.Count];
        
        for (int i = 0; i < enemyData.Count; i++)
        {
            Enemy enemy = Instantiate(_enemyTemplate, _enemyHolder.transform).GetComponent<Enemy>();
            enemy.Initialise(enemyData[i]);
            enemies[i] = enemy;
        }
        
        _enemyHolder.Reposition(enemies);
      
        return enemies;
    }
    
}
