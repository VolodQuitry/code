using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioType _type;
    [SerializeField] private bool _playOnAwake;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (_playOnAwake)
            Active(SaveData.TryGet(_type.ToString()));
    }

    public void Active(bool value)
    {
        if (value)
            _audio.Play();
        else
            _audio.Pause();
    }

    public void TryPlay()
    {
        Active(SaveData.TryGet(_type.ToString()));
    }
}
