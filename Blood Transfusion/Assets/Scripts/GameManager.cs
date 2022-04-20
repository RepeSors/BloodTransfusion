using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] WaterFlowScript checkWaterFlow;
    public static GameManager instance;

    public event Action gameStarted, scoreIncremented, scoreDecreased;
    bool isPlaying;
    bool handsWashed;
    bool platformDisinfected;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            StartGame();
        }

        if (checkWaterFlow.isActivated)
        {
            handsWashed = true;
            IncrementScore();
        }
    }

    public void StartGame()
    {
        gameStarted?.Invoke();
    }

    public void IncrementScore()
    {
        scoreIncremented?.Invoke();
    }

    public void DecreaseScore()
    {
        scoreDecreased?.Invoke();
    }


}
