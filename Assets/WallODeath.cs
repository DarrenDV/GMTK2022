using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallODeath : MonoBehaviour
{
    [SerializeField] private Analytics analytics;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            analytics.touchedWallOfDeath = true;
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
}
