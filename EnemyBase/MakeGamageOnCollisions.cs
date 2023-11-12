using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGamageOnCollisions : MonoBehaviour
{
    public int DamageValue = 1;
    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.GetComponent<PlayerHealth>())
            {
                other.rigidbody.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
            }
        }
        
    }
}
