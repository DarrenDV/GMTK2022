using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text text;
    private float score;
    [SerializeField] private float scorePerSecond;

    private void Start()
    {
        StartCoroutine(Score());
    }

    private IEnumerator Score()
    {
        while (true)
        {
            score += scorePerSecond / 4;
            yield return new WaitForSeconds(0.25f);
            text.text = "Score: " + score.ToString("0");
        }
    }
    
}
