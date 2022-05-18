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

        if (GameManager.instance.State != GameManager.GameState.Equipment && thisObject.Snapped)
        {
            GameManager.instance.waitsToGivePoints = true;
        }

        if (!GameManager.instance.hasWashed && !GameManager.instance.checkedPC && !GameManager.instance.platformDisinfected && thisObject.Snapped)
        {
            EnterFailedState();
        }
    }

    public void CheckIfCorrect()
    {
        GameManager.instance.correctLine = true;
        GameManager.instance.correctBag = true;
        GameManager.instance.UpdateGameState(GameManager.GameState.Insertion);
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
