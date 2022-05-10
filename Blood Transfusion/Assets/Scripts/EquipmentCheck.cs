using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCheck : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    private Oculus.Interaction.SnapToLocation thisObject;

    private void Start()
    {
        thisObject = GetComponent<Oculus.Interaction.SnapToLocation>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.State == GameManager.GameState.Equipment && thisObject.Snapped)
        {
            CheckIfCorrect();
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

        else
        {
            GameManager.instance.wrongLine = true;
            GameManager.instance.wrongBag = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.Failed);
        }
    }
}
