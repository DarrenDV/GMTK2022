using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text text;
    public float score;
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
