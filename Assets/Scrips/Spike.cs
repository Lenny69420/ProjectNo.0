using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D (Collider2D hitInfo )
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.DamageTaken(damage);
        }
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
}
}
