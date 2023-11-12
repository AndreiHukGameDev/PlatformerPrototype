using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SetTriggerEveryNSeconds : MonoBehaviour
{
    public float Period = 7.0f;
    public Animator Animator;
    private float _timer;
    public string TriggerName = "Attack";
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > Period)
        {
            _timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}
