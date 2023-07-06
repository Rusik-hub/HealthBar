using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(Slider))]
public class HealthBarPainter : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _hitPointsValue;

    private float _updateBarSpeed = 1f;
    private Slider _scale;

    private void Start()
    {
        _scale = GetComponent<Slider>();

        UpdateBar();
    }

    private void OnEnable()
    {
        _player.HealthIsChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _player.HealthIsChanged -= UpdateBar;
    }

    public void UpdateBar()
    {
        StartCoroutine(PaintBar());

        _hitPointsValue.text = $"{_player.Health}/{_player.MaxHealth}";
    }

    private IEnumerator PaintBar()
    {
        int health = _player.Health;

        while (_scale.value != health)
        {
            _scale.value = Mathf.MoveTowards(_scale.value, health, _updateBarSpeed);

            yield return new WaitForSeconds(0.015f);
        }
    }
}
