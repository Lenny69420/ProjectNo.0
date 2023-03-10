using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int damage = 1;
    [SerializeField] private float Speed;
    [SerializeField] private GameObject ArrowDeath;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right*Speed;    
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
    }
    IEnumerator SelfDestruct () 
    {
        yield return new WaitForSeconds(3f);
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
         Player player = hitInfo.GetComponent<Player>();
         if (player != null)
        {
            player.DamageTaken(damage);
        }
        Destroy(gameObject);
        Instantiate(ArrowDeath, transform.position, Quaternion.identity);

    }
    void TrackMovement()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
}
