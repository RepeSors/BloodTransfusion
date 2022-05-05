using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public bool scoreIncremented;
    public bool scoreIncremented2;
    public void CheckedPC()
    {
        if (!GameManager.instance.hasWashed && !scoreIncremented)
        {
            ScoreSystem.instance.IncrementScore();
            scoreIncremented = true;
            GameManager.instance.checkedPC = true;
            Debug.Log("vittu sä olet tyhmä");
        }

        else if (GameManager.instance.platformDisinfected)
        {
            ScoreSystem.instance.IncrementScore();
            scoreIncremented2 = true;
            GameManager.instance.checkedPC = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Equipment);
        }

        else if (GameManager.instance.State == GameManager.GameState.CheckPC)
        {
            GameManager.instance.checkedPC = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
        }
    }
}
