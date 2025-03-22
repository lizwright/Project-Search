using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private CenterHorizontalLayout _enemyHolder;

    private Bounds[] _bounds;

    public void SpawnEnemies(List<EnemyData> enemyData)
    {
        RemoveExistingEnemies();
        _bounds = new Bounds[enemyData.Count];
        Enemy[] enemies = new Enemy[enemyData.Count];
        
        for (int i = 0; i < enemyData.Count; i++)
        {
            Enemy enemy = Instantiate(_enemyTemplate, _enemyHolder.transform).GetComponent<Enemy>();
            enemy.Initialise(enemyData[i]);
            enemies[i] = enemy;
            _bounds[i] = enemy.GetComponent<Collider2D>().bounds;
        }
        
        float[] xPositions = _enemyHolder.CalculatePositions(_bounds);
        
        for (int i = 0; i < enemyData.Count; i++)
        {
            Transform enemyTransform = enemies[i].transform;
            enemyTransform.position = new Vector3(xPositions[i], enemyTransform.position.y, enemyTransform.position.z);
        }
    }
    
    private void RemoveExistingEnemies()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
