using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlowScript : MonoBehaviour
{
    [SerializeField] GameObject wateR;

    public void WaterGo()
    {
        wateR.SetActive(true);
        if (GameManager.instance.State == GameManager.GameState.WashHands && GameManager.instance.nextState == GameManager.GameState.CheckPC)
        {
            GameManager.instance.hasWashed = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.CheckPC);
        }

        if (GameManager.instance.State == GameManager.GameState.Disinfect)
        {
            GameManager.instance.platformDisinfected = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Equipment);
        }
        
    }

    public void WaterOff()
    {
        wateR.SetActive(false);
    }

    
}
