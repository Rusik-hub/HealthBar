using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _damage = 10;
    private int _minDamage = 1;

    public void HitPlayer()
    {
        if (_damage > 0)
            _player.TakeDamage(_damage);
        else
            _player.TakeDamage(_minDamage);
    }
}
