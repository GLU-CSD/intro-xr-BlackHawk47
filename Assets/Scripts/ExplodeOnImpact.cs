using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in coliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null )
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
