using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public int playerHealth;
    private Shake shake;
   [SerializeField] private ParticleSystem DeathParticle;
    [SerializeField] private GameObject lossMenu;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    void Awake()
    {
       Input.multiTouchEnabled = false;
    }
    void Start()
      {
         Time.timeScale = 1f;
         shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
      }
    public void DamageTaken (int damage)
    {
       playerHealth -= damage;
    if (playerHealth <= 0)
    {
      
        Die(); 
    }
 }
 void Die()
 {
    
    shake.CamShake();// Display animation
    FindObjectOfType<AudioManager>().Play("Death"); // Play sound
    Destroy(gameObject);
    lossMenu.SetActive(true);// Display loss menu
    pauseButton.SetActive(false);
    pauseMenu.SetActive(false);
    Instantiate(DeathParticle, transform.position, Quaternion.identity);// Blow into pieces
  
 }
 }

