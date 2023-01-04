using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatDisplay : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Text _health;
    [SerializeField] private Text _coin;

    private void OnEnable()
    {
        _target.OnHealthChanged += UpdateHealth;
        _target.OnCoinPicked += UpdateCoin;
    }

    private void OnDisable()
    {
        _target.OnHealthChanged -= UpdateHealth;
        _target.OnCoinPicked -= UpdateCoin;
    }

    private void UpdateHealth(int health)
    {
        _health.text = $"Health: {health}";
    }

    private void UpdateCoin(int coin)
    {
        _coin.text = $"Coin: {coin}";
    }
}
