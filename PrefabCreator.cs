using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PrefabCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform SpawnPosition;
    public void Create()
    {
        Instantiate(Prefab, SpawnPosition.position, SpawnPosition.rotation);
    }
}
