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
    public FallingFromSky fallingFromSky;

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
                fallingFromSky.StartSpawning();
                break;
            
            case "5":
                fallingFromSky.StartSpawning();
                break;
            
            case "6":
                fallingFromSky.StartSpawning();
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
