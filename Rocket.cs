using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 5.0f;
    public float RotationSpeed = 3.0f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMoved>().transform;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotarion = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotarion, Time.deltaTime * RotationSpeed);
        if (transform.position.z != 0.0f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }
    }
}
