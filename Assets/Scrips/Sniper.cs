using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class Sniper : MonoBehaviour
{
    //My proudest product
    [SerializeField] private int force = 40;
    [SerializeField] private float fireRate = 1f;
    private float nextFire = 0f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private LineRenderer line;
    GameObject[] enemies;
    GameObject player;
     void Update ()
    { 
        enemies = GameObject.FindGameObjectsWithTag("Enemy");    
        if (enemies.Length > 0)
        {
        if (Time.timeScale != 0f){
           if (Input.GetMouseButton(0))
        {

            StartCoroutine (Shoot()); 
            StopCoroutine (Shoot()) ; 
        }
           if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;// Disable laser
        } 
        }
        }else 
        {
            line.enabled = false;
        }
    }   
        
            
    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast (firePoint.position, firePoint.right);
        if (hitInfo)
        {
            line.SetPosition (0, firePoint.position);
            line.SetPosition (1, hitInfo.point);
        } else 
        {
            line.SetPosition (0, firePoint.position);
            line.SetPosition (1, firePoint.position + firePoint.right * 100); 
        }
        line.enabled = true;
        yield return 0;
        
    }
    public void ShootBullet () 
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
