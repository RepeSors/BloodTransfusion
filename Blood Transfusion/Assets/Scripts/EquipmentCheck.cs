using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCheck : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    [SerializeField] Oculus.Interaction.SnapToLocation thisObject;

    void Update()
    {
        if (GameManager.instance.State == GameManager.GameState.Equipment && thisObject.Snapped)
        {
            CheckIfCorrect();
        }

        if (!GameManager.instance.hasWashed && !GameManager.instance.checkedPC && !GameManager.instance.platformDisinfected && thisObject.Snapped)
        {
            EnterFailedState();
        }
    }

    public void CheckIfCorrect()
    {    
        if (thisObject.KiinnikeOsa.CompareTag("CorrectLine") && parentObject.CompareTag("CorrectBag"))
        {
            GameManager.instance.correctLine = true;
            GameManager.instance.correctBag = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Insertion);
        }

        else if (thisObject.KiinnikeOsa.CompareTag("CorrectLine") && parentObject.CompareTag("WrongBag"))
        {
            GameManager.instance.wrongBag = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.FailedEquipment);
        }

        else if (thisObject.KiinnikeOsa.CompareTag("WrongLine") && parentObject.CompareTag("CorrectBag"))
        {
            GameManager.instance.wrongLine = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.FailedEquipment);
        }

        else
        {
            GameManager.instance.wrongLine = true;
            GameManager.instance.wrongBag = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.FailedEquipment);
        }
    }

    public void EnterFailedState()
    {
        if (thisObject.KiinnikeOsa.CompareTag("CorrectLine") && parentObject.CompareTag("CorrectBag"))
        {
            GameManager.instance.waitsToGivePoints = true;
        }
        GameManager.instance.UpdateGameState(GameManager.GameState.Failed);
    }
}
