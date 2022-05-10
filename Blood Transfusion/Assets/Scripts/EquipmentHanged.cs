using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHanged : MonoBehaviour
{
    [SerializeField] Oculus.Interaction.SnapToLocation thisObject;

    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.State == GameManager.GameState.Insertion && thisObject.Snapped)
        {
            GameManager.instance.hasInserted = true;
            GameManager.instance.UpdateGameState(GameManager.GameState.MonitorPatient);
        }
    }
}
