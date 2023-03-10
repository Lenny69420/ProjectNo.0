using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shotgun : MonoBehaviour
{
    [SerializeField]private Transform firePoint;
    [SerializeField]private int force = 40;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private Animator anim;
    
    [SerializeField]private float fireRate = 1f;
    private float nextFire = 0f;
    [SerializeField]private int pettleCount;
    [SerializeField]private float spreadAngle;
    GameObject[] enemies;
    
    List<Quaternion> pellets;

    void Awake()
    {
        pellets = new List<Quaternion>(pettleCount);
        for  (int i = 0; i< pettleCount;i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }
   
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if( enemies.Length > 0)
        {
        if (Input.GetButton("Fire1"))
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
           for(int i = 0;i < pettleCount; i++)
           {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            i++;
           }
        }
        
    }
}
