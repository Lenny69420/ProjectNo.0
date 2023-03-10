using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeManager : MonoBehaviour
{
    private float slowMotionTimeScale = 0.1f;
    private float startTimeScale;
    private float startFixedDeltaTime;
    public Sniper sniper;
    GameObject player;
    GameObject[] enemies;

    //void Awake() { Input.multiTouchEnabled = false; }
    void Start()
    {
        startTimeScale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
          // A simple solution to the slow mo bug
        if (Time.timeScale != 0) 
        {
        if (Input.GetMouseButton(0)) // Activate slow motion 
        {
            if (player != null)
            {
            StartSlowMotion ();
            } else 
            {
                StopSlowMotion();
            }
        }  
        
        if (Input.GetMouseButtonUp(0))// Deactivate slow motion and shoot 
        {
            if (player != null)
            {
            StopSlowMotion();
            sniper.ShootBullet();
            }
        }
        }
        }else 
        {
            StopSlowMotion();
        } 
          
        
        
    }
    private void StartSlowMotion()
    {
        Time.timeScale = slowMotionTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimeScale;
    }
    public void StopSlowMotion()
    {
        Time.timeScale = startTimeScale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }

}
