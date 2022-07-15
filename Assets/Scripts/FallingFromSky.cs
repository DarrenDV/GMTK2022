using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFromSky : MonoBehaviour
{
    private float fallingSize = 10;
    private float spawnSpeed = 1f;

    [SerializeField] private GameObject[] fallingObjects;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnObject", 1f, spawnSpeed);
    }

    public void StopSpawning()
    {
        CancelInvoke();
    }

    void SpawnObject()
    {
        Vector3 positionOffset = new Vector3(Random.Range(-fallingSize, fallingSize), 0, Random.Range(-fallingSize, fallingSize));
        Vector3 instantiatePosition = positionOffset + gameObject.transform.position;
        Instantiate(fallingObjects[0], instantiatePosition, Quaternion.identity);
    }
}
