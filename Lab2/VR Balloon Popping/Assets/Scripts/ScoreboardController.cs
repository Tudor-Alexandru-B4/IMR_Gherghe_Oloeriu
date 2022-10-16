using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardController : MonoBehaviour
{
    TextMeshPro tmpro;
    int totalScore;

    // Start is called before the first frame update
    void Start()
    {
        tmpro = gameObject.GetComponent<TextMeshPro>();
        totalScore = 0;
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        tmpro.text = "Score: " + totalScore;
    }
}
