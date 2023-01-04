using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnRandomResource : MonoBehaviour
{
    [SerializeField] private List<Resource> _resources;
    [SerializeField] private Vector2 _max;
    [SerializeField] private Vector2 _min;
    [SerializeField] private float _cooldown;

    private void Start()
    {
        StartCoroutine(WaitSpawn());
    }

    public Resource GetRandomResource()
    {
        if (_resources.Count == 0)
            throw new ArgumentException(_resources.Count.ToString());

        int randomIndex = Random.Range(0, _resources.Count);
        return _resources[randomIndex];
    }

    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(_min.x, _max.x);
        float y = Random.Range(_min.y, _max.y);

        return new Vector2(x, y);
    }

    private IEnumerator WaitSpawn()
    {
        var waitForSeconds = new WaitForSeconds(_cooldown);

        while (true)
        {
            yield return waitForSeconds;
            Instantiate(GetRandomResource(), GetRandomPosition(), Quaternion.identity);
        }
    }
}
