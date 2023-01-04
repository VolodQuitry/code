using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    [SerializeField] private AudioPlayer _audioPlayer;
    [SerializeField] private GameObject _resourceImage;
    [SerializeField] private float _speedDown;

    private const float TimeDestroy = 2.5f;

    private bool _isEnterPlayer = false;

    private void Update()
    {
        transform.Translate(Vector3.down * _speedDown * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player) && _isEnterPlayer == false)
        {
            _isEnterPlayer = true;
            _audioPlayer.TryPlay();
            SetPlayer(player);
            Destroy();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Barrier barrier))
            Destroy(gameObject, TimeDestroy);
    }

    private void Destroy()
    {
        _resourceImage.SetActive(false);
        Destroy(gameObject, TimeDestroy);
    }

    protected abstract void SetPlayer(Player player);
}
