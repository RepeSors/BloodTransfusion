using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TeleporttausScribu tp;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManager_GameStarted;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManager_GameStarted;
    }

    private void GameManager_GameStarted(GameManager.GameState state)
    {
        tp.TeleporttausStart(state == GameManager.GameState.GameStart);
    }
}
