using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    private static Manager instance;
    
    
    public GameObject Dice;
    public DiceRoll diceRoll;

    public bool hasThrown;

    public GameObject diceCamImage;

    public DiceLava diceLava;
    public FallingFromSky fallingFromSky;
    public SpikeGenerator spikeGenerator;
    public ArenaSpinning arenaSpinning;
    public RoulletteBallShooter roulletteBallShooter;

    public bool effectActive;

    public static Manager Instance
    {
        get
        {
            if (instance is null)
            {
                instance = GameObject.FindObjectOfType<Manager>();
            }
            return instance;
        }
    }
        
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void ExecuteDiceResult(string diceSide)
    {
        switch (diceSide)
        {
            case "1":
                arenaSpinning.DiceEffect();
                break;
            
            case "2":
                spikeGenerator.RunDiceEffect();
                break;
            
            case "3":
                diceLava.StartDiceLava();
                break;
            
            case "4":
                fallingFromSky.StartSpawning();
                break;
            
            case "5":
                roulletteBallShooter.DiceEffect();
                break;
            
            case "6":
                //TODO ADD EFFECT
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
