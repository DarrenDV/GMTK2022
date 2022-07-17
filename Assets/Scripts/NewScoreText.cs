using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;
using TMPro;


public class NewScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float score;
    [SerializeField] private float scorePerSecond;

    public bool canAddScore = true;

    private void Start()
    {
        StartCoroutine(Score());
    }

    private IEnumerator Score()
    {
        while (canAddScore)
        {
            score += scorePerSecond / 4;
            Scoring.totalScore += 5;
            yield return new WaitForSeconds(0.25f);
            text.text = "Score: " + score.ToString("0");
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
