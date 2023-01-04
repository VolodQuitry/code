using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Toggle _music;
    [SerializeField] private Toggle _sound;

    private void Start()
    {
        _music.SetIsOnWithoutNotify(SaveData.TryGet(SaveData.Music));
        _sound.SetIsOnWithoutNotify(SaveData.TryGet(SaveData.Sound));
    }

    public void TryChangeValue(string key)
    {
        switch (key)
        {
            case SaveData.Music:
            case SaveData.Sound:
                ChangeValue(key);
                break;

            default:
                throw new ArgumentException(key);
        }
    }

    private void ChangeValue(string key)
    {
        bool result = SaveData.TryGet(key);
        result = !result;
        SaveData.Save(key, result);
    }
}
