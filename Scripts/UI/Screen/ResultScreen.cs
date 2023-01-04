using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScreen : Screen
{
    [SerializeField] private Text _message;

    public void ShowResult(Player player)
    {
        Show();
        Time.timeScale = 0;

        if (player != null)
        {
            _message.text = $"{player.Name} выиграл !";
        }
        else
        {
            _message.text = $"Ничья.";
        }
    }
}
