using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollicion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }
        if (DieOnAnyCollicion)
        {
            if (!other.isTrigger)
            {
                EnemyHealth.TakeDamage(10000);
            }
            
        }
        
    }
}
