using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject diceSpawnPoint;
    public static Vector3 diceVelocity;
    float torqueMultiplier = 500f;
    int maxTorqueRange = 1000;
    
    public void Throw()
    {
        rb.velocity = Vector3.zero;
        
        diceVelocity = rb.velocity;

        //Makes random dirs for the torque, this cannot be lower than 0
        float dirX = UnityEngine.Random.Range(0, maxTorqueRange);
        float dirY = UnityEngine.Random.Range(0, maxTorqueRange);
        float dirZ = UnityEngine.Random.Range(0, maxTorqueRange);

        //Standard position for the die
        transform.position = diceSpawnPoint.transform.position;

        transform.rotation = UnityEngine.Random.rotation;
        rb.AddForce(transform.up * torqueMultiplier);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
