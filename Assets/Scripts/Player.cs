using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private int _healValue = 10;
    private int _minDamage = 1;
    private int _minHealValue = 1;

    private void Awake()
    {
        MaxHealth = 100;
        Health = MaxHealth;
    }

    public int Health { get; private set; }
    public int MaxHealth { get; private set; }

    public void TakeDamage()
    {
        int damage = _enemy.GetDamageValue();

        if (damage > 0)
            Health -= damage;
        else
            Health -= _minDamage;

        if (Health < 0)
        {
            Health = 0;
        }
    }

    public void TakeHeal()
    {
        if (_healValue <= 0)
            Health += _minHealValue;
        else
            Health += _healValue;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
