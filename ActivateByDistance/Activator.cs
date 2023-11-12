using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> ObjectToActivate = new List<ActivateByDistance>();
    public Transform PlayerTransform;
    private void Update()
    {
        for (int i = 0; i < ObjectToActivate.Count; i++)
        {
            ObjectToActivate[i].CheckDistance(PlayerTransform.position);
        }
    }
}
