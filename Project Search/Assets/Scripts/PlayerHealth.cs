using System;
using UnityEngine;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public static event Action HealthChanged;
    public static event Action PlayerDied;

    [SerializeField] private int _startingHealth;

    public bool PlayerAlive => _health > 0;
    public int StartingHealth => _startingHealth;
    public int Health => _health;
    
    private int _health;

    protected override void Awake()
    {
        base.Awake();

        SetHealth(_startingHealth);

    }
    
    public void ReduceHealth(int amount)
    {
        _health -= amount;
        HealthChanged?.Invoke();
        if (_health <= 0)
        {
            PlayerDied?.Invoke();
        }
    }
    
    public void RestoreHealth(int amount)
    {
        _health += amount;
        HealthChanged?.Invoke();
    }

    public void SetHealth(int newValue)
    {
        _health = newValue;
        HealthChanged?.Invoke();
    }
    
}
