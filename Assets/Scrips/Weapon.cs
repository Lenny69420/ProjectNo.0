using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private int force = 40;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Animator anim;
    GameObject[] enemies;
    
    [SerializeField] private float fireRate = 1f;
     private float nextFire = 0f;
    

    
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
              {Shoot();}
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
            rb.AddForce(-transform.right * force);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
           
        }
        
    }
    
}
