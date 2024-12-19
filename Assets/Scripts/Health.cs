using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //hoeveelheid heal
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;
    public string prefabTag = "Enemy";

    //stelt begin health in
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
     //past de haelthbar aan als je damage krijgt
    void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }
    //zorgt er voor dat je damage krijgt
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if(currentHealth <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
    //zorgt er voor dat je kan healen
    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
}
