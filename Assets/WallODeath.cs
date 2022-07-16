using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallODeath : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
}
