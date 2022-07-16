using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideCheck : MonoBehaviour
{
    
    [SerializeField] private float secondsBeforeCheck = 3f;
    [SerializeField] private List<GameObject> diceSides = new List<GameObject>();
    [SerializeField] private Manager manager;
    [SerializeField] private GameObject diceCamImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (manager.hasThrown)
        {
            if (other.CompareTag("DiceSide"))
            {
                Debug.Log("Wejema");
                StartCoroutine(WaitSomeSecondsBeforeAccept());
            }
        }
    }

    private IEnumerator WaitSomeSecondsBeforeAccept()
    {
        yield return new WaitForSeconds(secondsBeforeCheck);
        CheckLandedDiceSide();
        
    }

    private void CheckLandedDiceSide()
    {
        StopAllCoroutines();
        GameObject highestDice = null;
        
        Debug.Log("Checking");
        
        foreach (var diceSide in diceSides)
        {
            if (highestDice == null)
            {
                highestDice = diceSide;
            }
            else
            {
                if (diceSide.transform.position.y > highestDice.transform.position.y)
                {
                    highestDice = diceSide;
                }
            }
        }
        
        //Debug.Log(highestDice.name);
        manager.ExecuteDiceResult(highestDice.name);
        manager.hasThrown = false;
        StartCoroutine(RemoveDiceImage());
    }

    private IEnumerator RemoveDiceImage()
    {
        yield return new WaitForSeconds(1f);
        diceCamImage.SetActive(false);
        
        StopAllCoroutines();
    }
}
