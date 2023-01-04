using System;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private string _sceneName;

    public void Play()
    {
        if (_sceneName == string.Empty)
            throw new NullReferenceException("Scene Name is Null");

        _loader.Load(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
