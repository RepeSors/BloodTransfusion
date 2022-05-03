using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public void CheckedPC()
    {
        if (GameManager.instance.State == GameManager.GameState.CheckPC)
        {
            GameManager.instance.checkedPC = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
        }
    }
}
