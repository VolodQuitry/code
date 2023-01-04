using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameControl : MonoBehaviour
{
    [SerializeField] private int _coinMax;
    [SerializeField] private List<Player> _players;

    private const int MaxWinPlayerCount = 1;

    public event UnityAction<Player> OnWinPlayer;

    private void Start()
    {
        Time.timeScale = 1;

        if (_players.Count == 0)
            throw new ArgumentNullException(_players.Count.ToString());
    }

    private void OnEnable()
    {
        foreach (var player in _players)
        {
            player.OnDie += TryShowWinner;
            player.OnCoinPicked += TryShowWinner;
        }
    }

    private void OnDisable()
    {
        foreach (var player in _players)
        {
            player.OnDie += TryShowWinner;
            player.OnCoinPicked += TryShowWinner;
        }
    }

    public Player TryGetFirstMaxCoinPlayer()
    {
        int coinMax = _players.Max(player => player.Coin);
        bool isIdenticalCoins = _players.All(player => player.Coin == coinMax);
        return isIdenticalCoins ? null : _players.FirstOrDefault(player => player.Coin == coinMax);
    }

    private void TryShowWinner()
    {
        var sorterdPlayerAlive = GetAlivePlayers();

        if (sorterdPlayerAlive.Count == MaxWinPlayerCount)
            OnWinPlayer?.Invoke(GetFirstWinPlayer());
    }

    private void TryShowWinner(int coin)
    {
        var player = GetMaxCoinPlayer();

        if (player != null)
            OnWinPlayer?.Invoke(GetMaxCoinPlayer());
    }

    private Player GetMaxCoinPlayer() => _players.FirstOrDefault(player => player.Coin == _coinMax);

    private List<Player> GetAlivePlayers() => _players.Where(player => player.IsAlive).ToList();

    private Player GetFirstWinPlayer() => _players.FirstOrDefault(player => player.IsAlive);
}
