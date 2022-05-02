using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TeleporttausScribu tp;
    [SerializeField] WaterFlowScript checkWaterFlow;
    [SerializeField] PlatformCollision hasCollided;
    public static GameManager instance;

    public GameState State;
    public GameState nextState;

    public static event Action<GameState> OnGameStateChanged;
    public bool hasWashed;
    public bool checkedPC;
    public bool platformDisinfected;

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
                HandlePC();
                break;
            case GameState.Disinfect:
                HandleDisinfect();
                break;
            case GameState.Equipment:
                HandleEquipment();
                break;
            case GameState.Insertion:
                HandleInsertion();
                break;
            case GameState.MonitorPatient:
                HandleMonitoring();
                break;
            case GameState.CheckEquipment:
                HandleChecking();
                break;
            case GameState.Results:
                HandleResults();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleResults()
    {
        throw new NotImplementedException();
    }

    private void HandleChecking()
    {
        throw new NotImplementedException();
    }

    private void HandleMonitoring()
    {
        throw new NotImplementedException();
    }

    private void HandleInsertion()
    {
        throw new NotImplementedException();
    }

    private void HandleEquipment()
    {
        if (platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Insertion;
    }

    private void HandleDisinfect()
    {
        if (checkedPC)
        {
            ScoreSystem.instance.IncrementScore();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Equipment;
    }

    private void HandlePC()
    {
        if (hasWashed)
        {
            ScoreSystem.instance.IncrementScore();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Disinfect;
    }

    private void HandleWashing()
    {
        Debug.Log("Current State: " + State);
        nextState = GameState.CheckPC;
    }

    private void HandleGameStart()
    {
        Debug.Log("Current State: " + State);
        ScoreSystem.instance.ResetScore();
        tp.TeleporttausStart();
        UpdateGameState(GameState.WashHands);
    }

    private void HandleTutorialRoom()
    {
        
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
        Results,
        AddScore,
        DecreaseScore
    }


}
