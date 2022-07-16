using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RouletteBall : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float startForceMax = 70f;
    [SerializeField] private float bounceForce = 50f;
    [SerializeField] private float timeAlive = 10f;

    [SerializeField] private float timeUntilPlayerCanTakeDamageAgain = 1.5f;

    private bool canTakeDamage = true;

    private void Start()
    {
        StartCoroutine(Die());
    }

    public void Launch(Vector3 direction)
    {
        rb.AddForce(direction * startForceMax, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;
            rb.AddForce(dir * bounceForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (canTakeDamage)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(20);
                StartCoroutine(CanTakeDamageAgain());
                canTakeDamage = false;
            }
        }
    }

    private IEnumerator CanTakeDamageAgain()
    {
        yield return new WaitForSeconds(timeUntilPlayerCanTakeDamageAgain);
        canTakeDamage = true;
        StopCoroutine(CanTakeDamageAgain());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timeAlive);
        Manager.Instance.effectActive = false;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
