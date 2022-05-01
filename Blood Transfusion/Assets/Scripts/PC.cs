using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            GameManager.instance.checkedPC = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Disinfect);
        }
    }
}
