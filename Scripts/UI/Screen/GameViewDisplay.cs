using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewDisplay : MonoBehaviour
{
    [SerializeField] private GameControl _control;
    [SerializeField] private ResultScreen _resultScreen;
    [SerializeField] private Timer _timer;

    private void OnEnable()
    {
        _control.OnWinPlayer += ShowWinWindow;
        _timer.OnTimeOver += ShowDrawWindow;
    }

    private void OnDisable()
    {
        _control.OnWinPlayer -= ShowWinWindow;
        _timer.OnTimeOver -= ShowDrawWindow;
    }

    private void ShowWinWindow(Player player)
    {
        _resultScreen.ShowResult(player);
    }

    private void ShowDrawWindow()
    {
        _resultScreen.ShowResult(_control.TryGetFirstMaxCoinPlayer());
    }
}
