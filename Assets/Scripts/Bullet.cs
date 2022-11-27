using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float secondsToDeath = 5f;
    public Rigidbody rb;
    [SerializeField] private float bounceForce = 5f;

    [SerializeField] private Analytics analytics;
    
    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(Vector3.forward * 10, ForceMode.Impulse);
        StartCoroutine(Die());
        analytics = GameObject.Find("AnalyticsManager").GetComponent<Analytics>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
            analytics.bulletHits++;
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * bounceForce, ForceMode.Impulse);
        }
    }
}
