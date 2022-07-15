using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public static Vector3 diceVelocity;
    float torqueMultiplier = 500f;
    int maxTorqueRange = 1000;

    //Variables for the position of the dice - changed in unity inspector - standard = new Vector3(2, 5, 10);
    public float posX, posY, posZ;

    //Gets the "throwable" bool from ButtonPress.cs
    public void Throw()
    {
        diceVelocity = rb.velocity;

        //Makes random dirs for the torque, this cannot be lower than 0
        float dirX = UnityEngine.Random.Range(0, maxTorqueRange);
        float dirY = UnityEngine.Random.Range(0, maxTorqueRange);
        float dirZ = UnityEngine.Random.Range(0, maxTorqueRange);

        //Standard position for the die
        transform.position = new Vector3(posX, posY, posZ);

        transform.rotation = UnityEngine.Random.rotation;
        rb.AddForce(transform.up * torqueMultiplier);
        rb.AddTorque(dirX, dirY, dirZ);
    }
}
