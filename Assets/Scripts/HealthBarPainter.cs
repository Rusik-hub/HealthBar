using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class HealthBarPainter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _hitPointsValue;

    private float _updateBarSpeed = 0.01f;

    private Slider _scale;

    private void Start()
    {
        _scale = GetComponent<Slider>();

        UpdateBar();
    }

    public void UpdateBar()
    {
        int health = _player.Health;

        while (_scale.value != health)
        {
            _scale.value = Mathf.MoveTowards(_scale.value, health, _updateBarSpeed);
        }

        _hitPointsValue.text = $"{_player.Health}/{_player.MaxHealth}";
    }
}
