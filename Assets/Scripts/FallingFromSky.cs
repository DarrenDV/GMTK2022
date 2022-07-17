using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFromSky : MonoBehaviour
{
    private float fallingSize = 40;
    [SerializeField] private float spawnSpeed = 1f;

    public float timeUntilStopping = 8f;

    [SerializeField] private GameObject[] fallingObjects;

    public void StartSpawning()
    {
        Manager.Instance.effectActive = true;  
        InvokeRepeating("SpawnObject", 0f, spawnSpeed);
        StartCoroutine(TimeUntilStop());
    }

    private IEnumerator TimeUntilStop()
    {
        yield return new WaitForSeconds(timeUntilStopping);
        StopSpawning();
        
    }

    public void StopSpawning()
    {
        StopCoroutine(TimeUntilStop());
        Manager.Instance.EffectHasStopped();
        CancelInvoke();
    }

    void SpawnObject()
    {
        Debug.Log("Aids");
        Vector3 positionOffset = new Vector3(Random.Range(-fallingSize, fallingSize), 0, Random.Range(-fallingSize, fallingSize));
        Vector3 instantiatePosition = positionOffset + gameObject.transform.position;
        //Vector3 instantiateRotation = new Vector3(Random.Range(-180, 180), 0, Random.Range(-180, 180));
        Instantiate(fallingObjects[1], instantiatePosition, Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)));
    }
}
