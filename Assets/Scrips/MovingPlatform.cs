using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int startingPoint;
    [SerializeField] private Transform[] points ;
    private int i ;
    void Start()
    {
        transform.position = points[startingPoint].position;
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D (Collision2D collision)
    {
       if(collision.transform.position.y > transform.position.y)
    {
        collision.transform.SetParent(transform);
    }
    }
    private void OnCollisionExit2D (Collision2D collision)
    {
        collision.transform.SetParent(null);

    }

}
