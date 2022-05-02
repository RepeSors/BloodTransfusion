using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public void CheckedPC()
    {
        GameManager.instance.checkedPC = true;
        GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
    }
}
