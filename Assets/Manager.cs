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
                DiceMessage("Arena is Going to Spin!");
                break;

            case "2":
                spikeGenerator.RunDiceEffect();
                DiceMessage("Spikes are coming out of the ground!");
                break;

            case "3":
                diceLava.StartDiceLava();
                DiceMessage("The floor will be lava!");
                break;

            case "4":
                fallingFromSky.StartSpawning();
                DiceMessage("Objects will fall from the sky!");
                break;

            case "5":
                roulletteBallShooter.DiceEffect();
                DiceMessage("A roullette ball will be launched!");
                break;

            case "6":
                guns.DiceEffect();
                DiceMessage("Faster guns!");
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
