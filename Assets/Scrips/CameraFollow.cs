using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity  = Vector3.zero;
    GameObject playerCurrent;
    GameObject [] enemiesCurrent;
    
    void FixedUpdate()
    {

        playerCurrent = GameObject.FindGameObjectWithTag("Player");
        enemiesCurrent = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesCurrent.Length == 0)
        {
            if (playerCurrent != null)
        {
            Vector3 targetPosition = playerCurrent.transform.position + offset;
            transform.position = Vector3.SmoothDamp ( transform.position, targetPosition, ref velocity, smoothTime);
        }else 
        {
            this.enabled = false;
        }
        }
    }   
}
