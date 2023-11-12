using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public GameObject HealthIconePrefab;
    public List<GameObject> HealthIcons = new List<GameObject>();

    public void SetUo(int maxHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            GameObject newHealthIcone = Instantiate(HealthIconePrefab, transform);
            HealthIcons.Add(newHealthIcone);
        }
        
    }

    public void DisplayHealth(int health)
    {
        for (int i = 0; i < HealthIcons.Count; i++)
        {
            if (i < health)
            {
                HealthIcons[i].SetActive(true);
            }
            else
            {
                HealthIcons[i].SetActive(false);
            }
        }
    }
    
}
