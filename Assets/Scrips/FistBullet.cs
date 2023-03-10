using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistBullet : MonoBehaviour
{
    [SerializeField] private float Speed = 20f;
   
    [SerializeField] private int damage;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right*Speed;
        StartCoroutine (SelfDestruct());
    }
    IEnumerator SelfDestruct () 
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
    void OnTriggerEnter2D (Collider2D hitInfo )
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

    }
}
