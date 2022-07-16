using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSpinning : MonoBehaviour
{
    public float spinningSpeed = 10f;
    private float defaultSpeed;

    public float diceEffectRoutineDuration;
    public float diceEffectRoutineEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        defaultSpeed = spinningSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,spinningSpeed * Time.deltaTime,0 );
    }

    public void DiceEffect()
    {
        StartCoroutine(DiceEffectCoroutine());
    }
    
    private IEnumerator DiceEffectCoroutine()
    {
        Manager.Instance.effectActive = true;
        spinningSpeed = diceEffectRoutineEffect;
        yield return new WaitForSeconds(diceEffectRoutineDuration);
        spinningSpeed = defaultSpeed;
        Manager.Instance.EffectHasStopped();
        StopCoroutine(DiceEffectCoroutine());
        
    }
}
