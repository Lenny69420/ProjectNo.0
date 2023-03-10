using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
   private Shake shake;
   [SerializeField] private ParticleSystem DeathParticle;
   [SerializeField] private int enemyHealth;
   
   void Start()
   {
      shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
   }
    
    public void TakeDamage ( int damage )
 {
    enemyHealth -= damage;
    if (enemyHealth <= 0)
    {
      
        Die();
    }
 }
   
 void Die ()
 {
    
    shake.CamShake();
    Destroy(gameObject);
    FindObjectOfType<AudioManager>().Play("Death");
    Instantiate(DeathParticle, transform.position, Quaternion.identity);
    
 }
}
