using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    private bool scoreIncremented;
    public void CheckedMonitor()
    {
        if (GameManager.instance.State == GameManager.GameState.MonitorPatient)
        {
            GameManager.instance.monitoredPatient = true;
            if (!scoreIncremented)
            {
                scoreIncremented = true;
                ScoreSystem.instance.IncrementScoreBy2();
            }
            GameManager.instance.UpdateGameState(GameManager.GameState.Results);
        }
    }
}
