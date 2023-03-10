using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private int force = 40;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator anim;
    
    [SerializeField] public float fireRate = 1f;
    private float nextFire = 0f;
    GameObject[] enemies;
    

    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
        if (Input.GetButton("Fire1"))
        {
              Shoot();
        }
        }
    }
    void Shoot () 
    {
        if (Time.time > nextFire )
        {
            nextFire = Time.time + fireRate;
            anim.SetTrigger("Shoot");
            FindObjectOfType<AudioManager>().Play("Shoot");
           rb.AddForce(transform.right * force);
           Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
           
        }
        
    }
}
