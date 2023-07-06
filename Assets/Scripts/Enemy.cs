using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _damage = 10;

    public int GetDamageValue()
    {
        return _damage;
    }
}
