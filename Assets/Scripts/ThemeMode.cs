using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeMode : MonoBehaviour
{
    [Header("CURRENT")]
    [SerializeField] Image currentColor;
    [SerializeField] Image currentImage;
    [SerializeField] TextMeshProUGUI currentTextColor;
    [Header("FUTURE")]
    [SerializeField] Sprite lightImage;
    [SerializeField] Sprite darkImage;
    [SerializeField] Color lightColor;
    [SerializeField] Color darkColor;
    

    void Start()
    {
        ////Set THEME on startup

    }

    void LateUpdate()
    {
        SetThemeMode();
    }
    void SetThemeMode()
    {
        if(GameManager.Instance.theme == GameManager.ThemeMode.Light)
        {
            currentImage.sprite = lightImage;
            currentColor.color = lightColor;

            currentTextColor.color = Color.black;
        }
        else if(GameManager.Instance.theme == GameManager.ThemeMode.Dark)
        {
            currentImage.sprite = darkImage;
            currentColor.color = darkColor;

            currentTextColor.color = Color.white;
        }
    }
}
