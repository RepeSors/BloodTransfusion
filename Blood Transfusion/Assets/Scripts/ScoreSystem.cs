using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreSystem : MonoBehaviour
{
    public int score { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        GameManager.instance.scoreIncremented += IncrementScore;
        GameManager.instance.scoreDecreased += DecreaseScore;
        GameManager.instance.gameStarted += DisplayScore;
    }

    void IncrementScore()
    {
        score++;
        DisplayScore();
    }

    void DecreaseScore()
    {
        score--;
        DisplayScore();
    }

    private void DisplayScore()
    {
        text.text = score.ToString();
    }
}
