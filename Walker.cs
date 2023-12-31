using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}
public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed;

    public float StopTime;
    private bool _isStopped;

    public Direction CurrentDirection;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    public Transform RayStart;
    
    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped)
        {
            return;
        }
        if (CurrentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0.0f, 0.0f);
            if (transform.position.x < LeftTarget.position.x)
            {
                CurrentDirection = Direction.Right;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0.0f, 0.0f);
            if (transform.position.x > RightTarget.position.x)
            {
                CurrentDirection = Direction.Left;
                _isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget.Invoke();
            }
        }

        RaycastHit hit;
        if (Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}

