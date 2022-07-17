using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private static Manager instance;

    //Dice rolling
    public GameObject Dice;
    public DiceRoll diceRoll;
    public bool hasThrown;
    public GameObject diceCamImage;

    //Dice reaction references
    public DiceLava diceLava;
    public FallingFromSky fallingFromSky;
    public SpikeGenerator spikeGenerator;
    public ArenaSpinning arenaSpinning;
    public RoulletteBallShooter roulletteBallShooter;
    public Guns guns;

    //Other references
    [SerializeField] private Text diceMessage;

    private float diceMessageTime = 3f;

    public bool effectActive;


    [SerializeField] private float firstDiceTime = 5f;
    public float timeBetweenRolls = 10f;

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

    private void Start()
    {
        StartCoroutine(FirstDiceRoll());
    }

    private IEnumerator FirstDiceRoll()
    {
        yield return new WaitForSeconds(firstDiceTime);
        RollDice();
        StopCoroutine(FirstDiceRoll());
    }

    private void RollDice()
    {
        diceCamImage.SetActive(true);
        hasThrown = true;
        diceRoll.Throw();
    }

    public void EffectHasStopped()
    {
        effectActive = false;
        StartCoroutine(DiceRollTimer());
    }

    private IEnumerator DiceRollTimer()
    {
        while(effectActive)
        {
            yield return null;
        }
        
        yield return new WaitForSeconds(timeBetweenRolls);
        RollDice();
        
        if (timeBetweenRolls > 0)
        {
            timeBetweenRolls -= 0.5f;
        }
        else
        {
            timeBetweenRolls = 0;
        }
        
        StopCoroutine(DiceRollTimer());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            diceLava.StartDiceLava();
        }
    }

    public void ExecuteDiceResult(string diceSide)
    {
        switch (diceSide)
        {
            case "1":
                //arenaSpinning.DiceEffect();
                roulletteBallShooter.DiceEffect();
                DiceMessage("Arena is Going to Spin!");
                break;

            case "2":
                //spikeGenerator.RunDiceEffect();
                roulletteBallShooter.DiceEffect();
                DiceMessage("Spikes are coming out of the ground!");
                break;

            case "3":
                //diceLava.StartDiceLava();
                roulletteBallShooter.DiceEffect();
                DiceMessage("The floor will be lava!");
                break;

            case "4":
                //fallingFromSky.StartSpawning();
                roulletteBallShooter.DiceEffect();
                DiceMessage("Objects will fall from the sky!");
                break;

            case "5":
                roulletteBallShooter.DiceEffect();
                DiceMessage("A roullette ball will be launched!");
                break;

            case "6":
                //guns.DiceEffect();
                roulletteBallShooter.DiceEffect();
                DiceMessage("More guns!");
                break;
        }
    }
    
    private void DiceMessage(string message)
    {
        diceMessage.text = message;
        diceMessage.enabled = true;
        StartCoroutine(WaitThenDisableDiceMessage());
    }

    private IEnumerator WaitThenDisableDiceMessage()
    {
        yield return new WaitForSeconds(diceMessageTime);
        diceMessage.enabled = false;
    }
}
