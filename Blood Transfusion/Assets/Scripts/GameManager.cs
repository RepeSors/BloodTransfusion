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
    public bool waitsToGivePoints;
    public bool hangedBloodBag;
    public bool checkedDripMachine;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.TutorialRoom);
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
            case GameState.FailedEquipment:
                HandleFailedEquipment();
                break;
            case GameState.Failed:
                HandleFailed();
                break;
                
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleFailed()
    {
        Debug.Log("Current State: " + State);
        Debug.Log("HUh mik‰ LusMu");
        nextState = GameState.WashHands;
        UpdateGameState(GameState.WashHands);
    }

    private void HandleFailedEquipment()
    {
        Debug.Log("lol v‰‰r‰t vehkeet");
        Debug.Log("Current State: " + State);
        nextState = GameState.Equipment;
        UpdateGameState(GameState.Equipment);
    }

    private void HandleResults()
    {
        throw new NotImplementedException();
    }

    private void HandleMonitoring()
    {
        ScoreSystem.instance.IncrementScoreBy2();
        Debug.Log("Current State: " + State);
        nextState = GameState.Results;
    }

    private void HandleInsertion()
    {   
        if (wrongBag || wrongLine || previousState != GameState.Equipment)
        {
            ScoreSystem.instance.IncrementScore();
        }
        else
        {
            ScoreSystem.instance.IncrementScoreBy2();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.MonitorPatient;
    }

    private void HandleEquipment()
    {
        if (platformDisinfected && previousState != GameState.WashHands)
        {
            ScoreSystem.instance.IncrementScoreBy2();
        }

        else if (previousState == GameState.WashHands)
        {
            ScoreSystem.instance.IncrementScore();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Insertion;
    }

    private void HandleDisinfect()
    {
        if (previousState == GameState.WashHands)
        {
            ScoreSystem.instance.IncrementScore();
        }

        else if (previousState == GameState.CheckPC)
        {
            ScoreSystem.instance.IncrementScoreBy2();
        }
        Debug.Log("Current State: " + State);
        nextState = GameState.Equipment;
    }

    private void HandlePC()
    {
        if (platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
        }

        else if (!platformDisinfected)
        {
            ScoreSystem.instance.IncrementScoreBy2();
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
        FailedEquipment,
        Failed
    }
}
