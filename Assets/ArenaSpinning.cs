using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpinning : MonoBehaviour
{
    public float spinningSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,spinningSpeed * Time.deltaTime,0 );
    }
}
