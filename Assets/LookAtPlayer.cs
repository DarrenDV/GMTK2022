using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3( player.transform.position.x, transform.position.y, player.transform.position.z );
        transform.LookAt( targetPostition ) ;
    }
}
