using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Dice;
    public DiceRoll diceRoll;

    public bool hasThrown;

    public GameObject diceCamImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            diceCamImage.SetActive(true);
            hasThrown = true;
            diceRoll.Throw();
            
        }
    }
}
