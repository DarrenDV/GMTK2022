using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject Dice;
    public DiceRoll diceRoll;

    public bool hasThrown;

    public GameObject diceCamImage;

    public DiceLava diceLava;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ExecuteDiceResult(string diceSide)
    {
        switch (diceSide)
        {
            case "1":
                diceLava.StartDiceLava();
                break;
            
            case "2":
                diceLava.StartDiceLava();
                break;
            
            case "3":
                diceLava.StartDiceLava();
                break;
            
            case "4":
                diceLava.StartDiceLava();
                break;
            
            case "5":
                diceLava.StartDiceLava();
                break;
            
            case "6":
                diceLava.StartDiceLava();
                break;
        }
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            diceLava.StartDiceLava();
        }
    }
}
