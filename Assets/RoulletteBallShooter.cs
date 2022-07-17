using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulletteBallShooter : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private AudioSource audioSource;

    public void DiceEffect()
    {
        Manager.Instance.effectActive = true;
        audioSource.Play();
        GameObject rouletteBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        rouletteBall.GetComponent<RouletteBall>().Launch(transform.right);
    }
}
