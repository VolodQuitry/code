using UnityEngine;

public static class SaveData
{
    public const string Music = nameof(Music);
    public const string Sound = nameof(Sound);

    public static bool Has(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void Save(string key, bool value)
    {
        PlayerPrefs.SetString(key, value.ToString());
    }

    public static string Get(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static bool TryGet(string key)
    {
        if (Has(key))
        {
            if (bool.TryParse(Get(key), out bool result))
                return result;
        }

        return true;
    }
}
