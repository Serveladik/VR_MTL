using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum ThemeMode { Light = 0, Dark = 1 };
    public ThemeMode theme = ThemeMode.Light;


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    public void SetLightTheme()
    {
        theme = ThemeMode.Light;
    }
    public void SetDarkTheme()
    {
        theme = ThemeMode.Dark;
    }
}
