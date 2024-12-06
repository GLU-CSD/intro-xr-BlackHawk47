using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public string prefabTag = "Enemy";
    private Health healthScript;

    void Update()
    {
        if (healthScript == null)
        {
            GameObject spawnedPrefab = GameObject.FindWithTag(prefabTag);
            if (spawnedPrefab != null)
            {
                healthScript = spawnedPrefab.GetComponent<Health>();
            }
        }
    }
    //als je de knop klikt gaat er health vanaf
    public void DamageButton()
    {
        if (healthScript != null)
        {
            healthScript.TakeDamage(10); // Vermindert health met 10
        }
    }
    //als je de knop klikt komt er health bij
    public void HealButton()
    {
        if (healthScript != null)
        {
            healthScript.RestoreHealth(10); // Herstelt health met 10
        }
    }
}
