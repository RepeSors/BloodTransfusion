using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public bool scoreIncremented;
    public void CheckedPC()
    {
        if (!GameManager.instance.hasWashed && !scoreIncremented)
        {
            ScoreSystem.instance.IncrementScore();
            scoreIncremented = true;
            GameManager.instance.checkedPC = true;
            Debug.Log("vittu sä olet tyhmä");
        }

        else if (GameManager.instance.State == GameManager.GameState.CheckPC)
        {
            GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
        }
    }
}
