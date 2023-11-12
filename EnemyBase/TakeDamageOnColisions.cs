using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnColisions : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollicion;
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }

        if (DieOnAnyCollicion)
        {
            EnemyHealth.TakeDamage(10000);
        }
        
    }
}
