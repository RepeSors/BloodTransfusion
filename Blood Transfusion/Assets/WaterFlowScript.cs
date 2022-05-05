using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlowScript : MonoBehaviour
{
    [SerializeField] GameObject wateR;

    public void WaterGo()
    {
        wateR.SetActive(true);
        if (GameManager.instance.checkedPC && GameManager.instance.State != GameManager.GameState.Disinfect)
        {
            GameManager.instance.hasWashed = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
        }
        else if (GameManager.instance.State == GameManager.GameState.WashHands)
        {
            GameManager.instance.hasWashed = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.CheckPC);
        }       
    }

    public void WaterOff()
    {
        wateR.SetActive(false);
    }

    
}
