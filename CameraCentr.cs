using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCentr : MonoBehaviour
{
    public Transform Target;
    public float LerpSpeed = 1.0f;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, LerpSpeed * Time.deltaTime);
    }
}
