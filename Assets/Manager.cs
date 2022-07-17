using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI diceMessage; //[SerializeField] private Text diceMessage;
    [SerializeField] private AudioSource ominousDiceSound;

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

    public void ExecuteDiceResult(string diceSide)
    {
        switch (diceSide)
        {
            case "1":
                arenaSpinning.DiceEffect();
                DiceMessage("Spin to win!"); // Arena is Going to Spin!
                break;

            case "2":
                spikeGenerator.RunDiceEffect();
                DiceMessage("The house always wins"); // Spikes are coming out of the ground!
                break;

            case "3":
                diceLava.StartDiceLava();
                DiceMessage("As long as you've got a chip and a chair, there's still hope"); // The floor will be lava! //As long as you’ve got ‘a chip and a chair’, there’s still hope //You've got to know when to fold 'em!
                break;

            case "4":
                fallingFromSky.StartSpawning();
                DiceMessage("You hit the jackpot, of death!"); // Objects will fall from the sky!
                break;

            case "5":
                roulletteBallShooter.DiceEffect();
                DiceMessage("Everything on RED!"); // A roullette ball will be launched!
                break;

            case "6":
                guns.DiceEffect();
                DiceMessage("Luck of the draw!"); // More guns!
                break;
        }
    }
    
    private void DiceMessage(string message)
    {
        ominousDiceSound.Play();
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
