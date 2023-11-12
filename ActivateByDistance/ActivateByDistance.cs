using System;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    public float DistanceToActive = 20.0f;

    private bool _isActive = true;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.ObjectToActivate.Add(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (_isActive)
        {
            if (distance > DistanceToActive + 2.0f && _isActive)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < DistanceToActive && !_isActive)
            {
                Activate();
            }
        }
        

        
    }
    
    
    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _activator.ObjectToActivate.Remove(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.gray;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActive);
    }
#endif
}
