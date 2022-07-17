using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceLava : MonoBehaviour
{
    [SerializeField] private GameObject platforms;
    [SerializeField] private GameObject arena;
    [SerializeField] private AudioSource audioSource;
    
    public float timeUntilLavaStarts = 5f;
    public float timeLavaStays = 10f;
    
    public bool lavaIsActive = false;

    public void StartDiceLava()
    {
        StartCoroutine(BeginDiceLava());
    }

    private IEnumerator BeginDiceLava()
    {
        //Start Dice lava
        Manager.Instance.effectActive = true;
        platforms.SetActive(true);

        yield return new WaitForSeconds(timeUntilLavaStarts);

        arena.SetActive(false);
        audioSource.Play();
        lavaIsActive = true;

        //Wait in dice lava
        yield return new WaitForSeconds(timeLavaStays);


        //Stop dice lava
        audioSource.Stop();
        arena.SetActive(true);
        yield return new WaitForSeconds(0.25f);

        platforms.SetActive(false);


        lavaIsActive = false;

        Manager.Instance.EffectHasStopped();
        
        
        StopCoroutine(BeginDiceLava());
    }
}
