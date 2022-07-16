using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float secondsToDestroy = 3f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
        StartCoroutine(WaitThenDestroy());
    }

    private IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(secondsToDestroy);
        StopAllCoroutines();
        Destroy(gameObject);
    }

}
