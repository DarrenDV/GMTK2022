using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceFollow : MonoBehaviour
{
    public GameObject dice;
    public float hightAmount = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = dice.transform.position;
        position.y += hightAmount;
        transform.position = position;
    }
}
