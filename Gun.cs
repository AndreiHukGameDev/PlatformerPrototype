using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Spawn;
    public float ShotPeriod = 0.2f;
    public GameObject BulletPrefab;
    public Transform BulletsContainers;
    public float BulletSpeed = 10.0f;

    public AudioSource ShotSound;
    public GameObject Flash;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && _timer > ShotPeriod)
        {
            _timer = 0f;
            GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation,BulletsContainers);
            newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
            ShotSound.Play();
            Flash.SetActive(true);
            Invoke("HideFlash", 0.12f);
        }
    }

    public void HideFlash()
    {
        Flash.SetActive(false);
    }
}
