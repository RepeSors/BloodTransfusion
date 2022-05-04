using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHanged : MonoBehaviour
{
    private SnapToLocation thisObject;

    private void Start()
    {
        thisObject = GetComponent<SnapToLocation>();
    }
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
