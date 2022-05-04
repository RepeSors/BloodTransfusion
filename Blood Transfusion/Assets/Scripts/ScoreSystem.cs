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
    public static string failedText { get; set; } = null;
    [SerializeField] private TextMeshProUGUI text;

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

    public void DecreaseScore()
    {
        score--;
        DisplayScore();
    }

    public void FailedText()
    {
        failedText = "Something went wrong with the equipment";
    }

    public void DisplayScore()
    {
        text.text = score.ToString();
    }

    public void DisplayFailedText()
    {
        text.text = failedText;
    }


}
