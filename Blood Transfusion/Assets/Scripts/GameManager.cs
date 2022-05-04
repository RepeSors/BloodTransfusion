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
    public GameState previousState;

    public static event Action<GameState> OnGameStateChanged;
    public bool hasWashed;
    public bool checkedPC;
    public bool platformDisinfected;
    public bool correctBag;
    public bool correctLine;
    public bool wrongBag;
    public bool wrongLine;
    public bool hasInserted;

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
        previousState = State;
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
            case GameState.Results:
                HandleResults();
                break;
            case GameState.Failed:
                HandleFailed();
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleFailed()
    {
        ScoreSystem.instance.DisplayFailedText();
        Debug.Log("Current State: " + State);
        nextState = GameState.Equipment;
    }

    private void HandleResults()
    {
        throw new NotImplementedException();
    }

    private void HandleMonitoring()
    {
        ScoreSystem.instance.IncrementScore();
        Debug.Log("Current State: " + State);
        nextState = GameState.MonitorPatient;
    }

    private void HandleInsertion()
    {
        ScoreSystem.instance.IncrementScore();
        Debug.Log("Current State: " + State);
        nextState = GameState.MonitorPatient;
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
        Debug.Log("Current State: " + State);
        tp.TeleporttausTutorial();
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
        Results,
        Failed
    }
}
