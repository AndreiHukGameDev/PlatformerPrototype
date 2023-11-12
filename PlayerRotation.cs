using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform Aim;
    private float _maxAngle = -30.0f;
    private float _rotateSpeed = 5.0f;

    private void Update()
    {
        if (Aim.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(_maxAngle, Vector3.up), _rotateSpeed * Time.deltaTime);
        }
        else if (Aim.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(Mathf.Abs(_maxAngle), Vector3.up), _rotateSpeed * Time.deltaTime);
        }
    }
}
