using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody CarrotRb;
    public float Speed;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMoved>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        CarrotRb.velocity = toPlayer * Speed;
    }

    
}
