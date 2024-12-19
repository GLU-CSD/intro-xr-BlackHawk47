using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SwordDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damageAmount = 10;

    [Header("Enemy Tag")]
    public string enemyTag = "Enemy";

    [Header("Motion Settings")]
    public float minVelocity = 1.0f; // Minimum snelheid voor schade

    [Header("Cooldown Settings")]
    public float hitCooldown = 0.5f; // Time between successive hits

    private Vector3 lastPosition;
    private Vector3 velocity;

    private HashSet<GameObject> recentlyHitEnemies = new HashSet<GameObject>();

    private void Start()
    {
        // Onthoud de startpositie van het zwaard
        lastPosition = transform.position;
    }

    private void Update()
    {
        // Bereken de snelheid van het zwaard
        velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het object een vijand is
        if (other.CompareTag(enemyTag))
        {
            // Controleer of het zwaard snel genoeg beweegt om schade toe te brengen
            if (velocity.magnitude >= minVelocity)
            {
                DealDamage(other.gameObject);
            }
        }
    }

    private void DealDamage(GameObject enemy)
    {
        // Zoek naar een Health-component op de vijand
        Health enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damageAmount);
        }
        else
        {
            Debug.LogWarning("Enemy object heeft geen Health-component.");
        }


    }

    private IEnumerator RemoveFromCooldown(GameObject enemy)
    {
        yield return new WaitForSeconds(hitCooldown);
        recentlyHitEnemies.Remove(enemy);
    }


}


