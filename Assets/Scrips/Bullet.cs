using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed = 20f;
   
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletParticle;
   
    void Start()
    {
        rb.velocity = transform.right*Speed;
        StartCoroutine (SelfDestruct());
    }
    IEnumerator SelfDestruct () 
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Crate crate = hitInfo.GetComponent<Crate>();
         if (crate != null)
        {
            crate.TakeDamage(damage);
        }

         Destroy(gameObject);
         Instantiate(bulletParticle, transform.position, Quaternion.identity);

    }
   
}
