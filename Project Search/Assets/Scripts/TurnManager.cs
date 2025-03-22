using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private ResourceHolder _resourceHolder;
    [SerializeField] private Transform _enemyHolder;

    public void EnterOutOfCombat()
    {
        InputManager.DisableGameInput();
    }
    
    public void StartPlayerTurn()
    {
        _resourceHolder.RefreshResources();
        
        InputManager.EnableGameInput();
    }

    public void EndPlayerTurn()
    {
        InputManager.DisableGameInput();
        StartEnemyTurn();
    }
    
    private void StartEnemyTurn()
    {
        List<Enemy> enemies = new List<Enemy>(_enemyHolder.GetComponentsInChildren<Enemy>());

        foreach (Enemy enemy in enemies)
        {
            enemy.TakeTurn();
        }
        
        StartPlayerTurn();

    }
    
}
