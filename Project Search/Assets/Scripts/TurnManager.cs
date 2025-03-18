using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField] private ResourceHolder _resourceHolder;
    [SerializeField] private Transform _enemyHolder;

    private List<Enemy> _enemies;
    
    private void Awake()
    {
        _enemies = new List<Enemy>(_enemyHolder.GetComponentsInChildren<Enemy>());
    }

    public void Start()
    {
        StartPlayerTurn();
    }
    
    private void StartPlayerTurn()
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
        foreach (Enemy enemy in _enemies)
        {
            enemy.TakeTurn();
        }
        
        StartPlayerTurn();

    }
    
}
