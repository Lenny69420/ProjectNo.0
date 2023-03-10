using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
     private Shake shake;
   [SerializeField] private ParticleSystem DeathParticle;
   
   void Start()
   {
      shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
   }
    [SerializeField] private int crateHealth;
    public void TakeDamage ( int damage )
 {
    crateHealth -= damage;
    if (crateHealth <= 0)
    {
      
        Die();
    }
 }
   
 void Die ()
 {
    
    shake.CamShake();
    FindObjectOfType<AudioManager>().Play("CrateDeath"); 
    Destroy(gameObject);
    Instantiate(DeathParticle, transform.position, Quaternion.identity);
 }
}
