using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private HealthBarPainter _painter;
    [SerializeField]private UnityEvent _healthIsChanged;

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

    public event UnityAction HealthIsChanged
    {
        add => _healthIsChanged.AddListener(value);
        remove => _healthIsChanged.RemoveListener(value);
    }

    public void TakeDamage()
    {
        StartCoroutine(TakeDamageCoroutine());
        StopCoroutine(TakeDamageCoroutine());
        _healthIsChanged?.Invoke();
    }

    public void TakeHeal()
    {
        StartCoroutine(TakeHealCoroutine());
        StopCoroutine(TakeHealCoroutine());
        _healthIsChanged?.Invoke();
    }

    private IEnumerator TakeDamageCoroutine()
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

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator TakeHealCoroutine()
    {
        if (_healValue <= 0)
            Health += _minHealValue;
        else
            Health += _healValue;

        if (Health > MaxHealth)
            Health = MaxHealth;

        yield return new WaitForSeconds(1f);
    }
}
