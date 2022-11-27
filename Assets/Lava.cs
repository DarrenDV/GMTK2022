using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Analytics analytics;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            analytics.fellInLava = true;
            collision.gameObject.GetComponent<Health>().TakeDamage(100);
        }
    }
}
