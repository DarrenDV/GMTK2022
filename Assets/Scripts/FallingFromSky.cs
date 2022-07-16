using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFromSky : MonoBehaviour
{
    private float fallingSize = 40;
    private float spawnSpeed = 1f;

    [SerializeField] private GameObject[] fallingObjects;

    // Start is called before the first frame update
    void Start()
    {
        //StartSpawning();
    }

    public void StartSpawning()
    {
        Manager.Instance.effectActive = true;  
        InvokeRepeating("SpawnObject", 1f, spawnSpeed);
    }

    public void StopSpawning()
    {
        Manager.Instance.effectActive = false;
        CancelInvoke();
    }

    void SpawnObject()
    {
        Vector3 positionOffset = new Vector3(Random.Range(-fallingSize, fallingSize), 0, Random.Range(-fallingSize, fallingSize));
        Vector3 instantiatePosition = positionOffset + gameObject.transform.position;
        //Vector3 instantiateRotation = new Vector3(Random.Range(-180, 180), 0, Random.Range(-180, 180));
        Instantiate(fallingObjects[1], instantiatePosition, Quaternion.Euler(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180)));
    }
}
