using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    public int score { get; private set; } = 0;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
        GameManager.OnGameStateChanged += GameManager_GameStarted;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_GameStarted;
    }

    private void GameManager_GameStarted(GameManager.GameState state)
    {
        ResetScore(state == GameManager.GameState.GameStart);
        DisplayScore(state == GameManager.GameState.GameStart);
    }

    private void Start()
    {
        GameManager.instance.scoreIncremented += IncrementScore;
        GameManager.instance.scoreDecreased += DecreaseScore;
    }

    void ResetScore(bool state)
    {
        score = 0;
    }

    void IncrementScore()
    {
        score++;
    }

    void DecreaseScore()
    {
        score--;
    }

    void DisplayScore(bool state)
    {
        text.text = score.ToString();
    }
}
