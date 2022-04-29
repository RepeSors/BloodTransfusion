using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] WaterFlowScript checkWaterFlow;
    [SerializeField] PlatformCollision hasCollided;
    public static GameManager instance;

    public GameState State;

    public event Action scoreIncremented, scoreDecreased;
    public static event Action<GameState> OnGameStateChanged;
    bool isPlaying;
    bool handsWashed;
    bool platformDisinfected;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.GameStart);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.TutorialRoom:
                HandleTutorialRoom();
                break;
            case GameState.GameStart:
                HandleGameStart();
                break;
            case GameState.WashHands:
                HandleWashing();
                break;
            case GameState.CheckPC:
                break;
            case GameState.Disinfect:
                break;
            case GameState.Equipment:
                break;
            case GameState.Insertion:
                break;
            case GameState.MonitorPatient:
                break;
            case GameState.CheckEquipment:
                break;
            case GameState.Results:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleWashing()
    {
        if (checkWaterFlow)
        {
            IncrementScore();
        }
    }

    private void HandleGameStart()
    {
        
    }

    private void HandleTutorialRoom()
    {
        
    }

    /*
    void Update()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            
        }

        if (checkWaterFlow.isActivated)
        {
            handsWashed = true;
            if (ScoreSystem.instance.score < 1)
            {
                IncrementScore();
            }
        }

        if (handsWashed && hasCollided.isDisinfected)
        {
            platformDisinfected = true;
            if (ScoreSystem.instance.score < 2)
            {
               IncrementScore();
            }
        }

        else if (!handsWashed && hasCollided.isDisinfected)
        {
            if (ScoreSystem.instance.score == 0)
            {
                DecreaseScore();
            }
        }


    }*/

    public void IncrementScore()
    {
        scoreIncremented?.Invoke();
    }

    public void DecreaseScore()
    {
        scoreDecreased?.Invoke();
    }

    public enum GameState
    {
        TutorialRoom,
        GameStart,
        WashHands,
        CheckPC,
        Disinfect,
        Equipment,
        Insertion,
        MonitorPatient,
        CheckEquipment,
        Results
    }


}
