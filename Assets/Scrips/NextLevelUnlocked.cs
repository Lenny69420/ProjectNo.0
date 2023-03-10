using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelUnlocked : MonoBehaviour
{
    private int nextSceneLoad;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        Time.timeScale = 1f;
    }
    public void Win()
    {
        SceneManager.LoadSceneAsync(nextSceneLoad);
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }
}
