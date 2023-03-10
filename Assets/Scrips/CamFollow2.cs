using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow2 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.2f;
    private Vector3 velocity  = Vector3.zero;
    [SerializeField] private Transform target;
    GameObject playerCurrent;
    GameObject [] enemiesCurrent;
    
    
    // Update is called once per frame
    void FixedUpdate()
    {

        playerCurrent = GameObject.FindGameObjectWithTag("Player");
        enemiesCurrent = GameObject.FindGameObjectsWithTag("Enemy");
            if (playerCurrent != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp ( transform.position, targetPosition, ref velocity, smoothTime);
        }else 
        {
            this.enabled = false;
        }
    }   
}
