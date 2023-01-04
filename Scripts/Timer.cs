using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _startTime;

    public event UnityAction<int> OnTimeChanged;
    public event UnityAction OnTimeOver;

    private void Start()
    {
        StartCoroutine(WaitTime());
    }

    private IEnumerator WaitTime()
    {
        var waitForSeconds = new WaitForSeconds(1);

        while (_startTime > 0)
        {
            OnTimeChanged?.Invoke(_startTime--);
            yield return waitForSeconds;
        }

        OnTimeChanged?.Invoke(_startTime);
        OnTimeOver?.Invoke();
    }
}
