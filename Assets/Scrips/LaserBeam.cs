using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private LineRenderer line;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private float force;
    [SerializeField] private int damage;
    [SerializeField] private float soundRate = 1f;
    private float nextFire = 0f;
    GameObject[] enemies;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
        if (Input.GetMouseButton(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
              {
            rb.AddForce(-transform.right * force);
            anim.SetTrigger("Shoot");
            Sound();
            StopCoroutine (Shoot ());
            StartCoroutine (Shoot ());
              }
        }
        if (Input.GetMouseButtonUp(0))
        {
            line.enabled = false;
        }
        } else 
        {
            line.enabled = false;
        }
        
    }
    IEnumerator Shoot ()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
        if (hitInfo)
        { 
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
           Crate crate = hitInfo.transform.GetComponent<Crate>();
           if (crate != null)
        {
            crate.TakeDamage(damage);
        }
            line.SetPosition(0 , FirePoint.position);
            line.SetPosition(1 , hitInfo.point);
        } else 
        {
            line.SetPosition(0 , FirePoint.position);
            line.SetPosition(1 , FirePoint.position + FirePoint.right * 100);
        }
        line.enabled = true;
        
        yield return 0;
        

    }
    void Sound()
    {
        if (Time.time > nextFire )
        {
            nextFire = Time.time + soundRate;
            FindObjectOfType<AudioManager>().Play("Shoot"); 
        }
        
    }
}
