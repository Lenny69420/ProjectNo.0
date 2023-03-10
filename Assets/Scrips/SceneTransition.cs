using System.Collections;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
   GameObject[] enemies;
   GameObject playerCurrent;
   [SerializeField] private Animator camAnim;
   [SerializeField] private GameObject winMenu;
   [SerializeField] private GameObject pauseMenu;
   [SerializeField] private GameObject pauseButton;
   

   void Start()
   {
     AudioListener.pause = false; //Enable sound for next level
     playerCurrent = GameObject.FindGameObjectWithTag("Player");  
     
   }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");// Check the amount of remaining enemies
        if (enemies.Length == 0)
        {
            WinRound();
        }
    }
    
    IEnumerator WaitTillNextScene()
    {
        yield return new WaitForSeconds(2f);
        if(playerCurrent != null) // Another 5Head moment
        {
          winMenu.SetActive(true);// Fix the display bug when player kills the last enemy but die at the same moment 
          AudioListener.pause = true;// Disable sound when win menu is displayed
          Destroy(playerCurrent);// Fix the sniper's slow-mo bug
        }
    }
    IEnumerator WaitTillWin()
    {
        yield return new WaitForSeconds(0.5f);
        if(playerCurrent != null)
        {
            camAnim.SetTrigger("Win");
        }
    }
    void WinRound()
    {
        Time.timeScale = 1f;
        StartCoroutine(WaitTillNextScene());
        StartCoroutine(WaitTillWin());
        pauseMenu.SetActive(false);
        pauseButton.SetActive(false);
        if(playerCurrent != null)
        {
        playerCurrent.GetComponent<Player>().playerHealth = 999;
        }
            
    }
}

