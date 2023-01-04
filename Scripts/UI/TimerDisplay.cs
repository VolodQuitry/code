using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private Text _text;

    private const int Minute = 60;
    private const int Seconds = 60;

    private void OnEnable()
    {
        _timer.OnTimeChanged += UpdateTimer;
    }

    private void OnDisable()
    {
        _timer.OnTimeChanged -= UpdateTimer;
    }

    private void UpdateTimer(int time)
    {
        int minute = time / Minute;
        int seconds = time % Seconds;

        _text.text = $"{minute.ToString("00")}:{seconds.ToString("00")}";
    }
}
