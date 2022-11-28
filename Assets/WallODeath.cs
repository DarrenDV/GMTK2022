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
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            analytics.touchedWallOfDeath = true;
            Debug.Log(analytics.touchedWallOfDeath);
            other.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
}
