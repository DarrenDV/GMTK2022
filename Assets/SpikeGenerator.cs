using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikeGenerator : MonoBehaviour
{
    public int spikesToGenerate = 10;

    public float spikeWarningTime = 1f;
    public float spikeALiveTime = 3f;

    [SerializeField] private GameObject spikeParent, spikeWarningParent;
    
    
    public GameObject spikeWarning;
    public GameObject spike;


    public void RunDiceEffect()
    {
        Manager.Instance.effectActive = true;
        SpawnSpikeWarnings();
    }

    private void SpawnSpikeWarnings()
    {
        for (int i = 0; i < spikesToGenerate; i++)
        {
            Vector2 spikePos = Random.insideUnitCircle * 50;
            GameObject go = Instantiate(spikeWarning, new Vector3(spikePos.x, 0.25f, spikePos.y), Quaternion.identity);
            go.transform.parent = spikeWarningParent.transform;
        }

        StartCoroutine(SpikeWarningTimer());
    }

    private IEnumerator SpikeWarningTimer()
    {
        yield return new WaitForSeconds(spikeWarningTime);
        SpawnSpikes();
        StopCoroutine(SpikeWarningTimer());
    }

    private void SpawnSpikes()
    {
        //Spikes audio
        gameObject.GetComponent<AudioSource>().Play();
        
        foreach (Transform child in spikeWarningParent.transform)
        {
            GameObject go = Instantiate(spike, child.position, Quaternion.identity);
            go.transform.parent = spikeParent.transform;
            Destroy(child.gameObject);
        }

        StartCoroutine(EndSpikes());
    }


    private IEnumerator EndSpikes()
    {
        yield return new WaitForSeconds(spikeALiveTime);
        foreach (Transform child in spikeParent.transform)
        {
            Destroy(child.gameObject);
        }
        
        Manager.Instance.EffectHasStopped();
        StopCoroutine(EndSpikes());
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            RunDiceEffect();
        }
    }
}
