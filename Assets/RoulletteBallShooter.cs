using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteBallShooter : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    public void DiceEffect()
    {
        Manager.Instance.effectActive = true;
        GameObject rouletteBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        rouletteBall.GetComponent<RouletteBall>().Launch(transform.up);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            DiceEffect();
        }
    }
}
