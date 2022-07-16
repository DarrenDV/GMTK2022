using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float secondsToDeath = 5f;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(secondsToDeath);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    // Jelle bullet does damage
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         other.gameObject.GetComponent<Health>().TakeDamage(10);
    //         Destroy(gameObject);
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
