using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //public Animator anim;
   [SerializeField] public GameObject pauseMenuUI;
   
    //Adding pause menu causes too much problem so just scrap it anyway
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Home (int sceneID) // Same applied to levels (IT'S A LIE !!!)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
