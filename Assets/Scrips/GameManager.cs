using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     public AdManager ads;
    public Button[] lvlButtons;
    void Start()
    {
        Time.timeScale = 1f;
        int levelAt = PlayerPrefs.GetInt("levelAt",2 );
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i+2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }

        }
        ads.ShowBanner();
    }
}
