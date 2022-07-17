using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpinning : MonoBehaviour
{
    public float spinningSpeed = 10f;
    private float defaultSpeed;

    public float diceEffectRoutineDuration;
    public float diceEffectRoutineEffect;

    private int score;
    [SerializeField] private Scoring scoring;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = spinningSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,spinningSpeed * Time.deltaTime,0 );
        
        score = Scoring.totalScore;
    }
    

    public void DiceEffect()
    {
        StartCoroutine(DiceEffectCoroutine());
    }
    
    private IEnumerator DiceEffectCoroutine()
    {
        Manager.Instance.effectActive = true;
        spinningSpeed = CalculateNewSpeed();
        yield return new WaitForSeconds(diceEffectRoutineDuration);
        spinningSpeed = defaultSpeed;
        Manager.Instance.EffectHasStopped();
        StopCoroutine(DiceEffectCoroutine());
        
    }

    private float CalculateNewSpeed()
    {
        float newSpeed = 0f;

        newSpeed = defaultSpeed + (score / 50f);    
        
        return newSpeed;
    }
}
