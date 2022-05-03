using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPullo : MonoBehaviour
{
    public GameObject vesiEff;


    public void SprayOn()
    {
        vesiEff.SetActive(true);
        if (GameManager.instance.State == GameManager.GameState.Disinfect)
        {
            GameManager.instance.platformDisinfected = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Equipment);
        }
    }

    public void SprayOff()
    {
        vesiEff.SetActive(false);
    }


}
