using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public static int score { get; set; } = 0;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        instance = this;       
    }  

    public void ResetScore()
    {
        score = 0;
        DisplayScore();
    }

    public void IncrementScore()
    {
        score++;
        DisplayScore();
    }

    public void IncrementScoreBy2()
    {
        score += 2;
        DisplayScore();
    }

    public void DecreaseScore()
    {
        score--;
        DisplayScore();
    }

    public void DisplayScore()
    {
        text.text = score.ToString();
    }

    


}
