using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody HenRigidbody;
    public float TimeToMaxSpeed;
    public float Speed;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMoved>().transform;
    }

    private void Update()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = HenRigidbody.mass * (toPlayer * Speed - HenRigidbody.velocity) / TimeToMaxSpeed;
        HenRigidbody.AddForce(force);
    }
}
