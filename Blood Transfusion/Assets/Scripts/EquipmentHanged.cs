using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentHanged : MonoBehaviour
{
    [SerializeField] Oculus.Interaction.SnapToLocation thisObject;
    [SerializeField] GameObject tube;

    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.State == GameManager.GameState.Insertion && thisObject.Snapped)
        {
            tube.SetActive(true);
            GameManager.instance.hangedBloodBag = true;
        }
    }
}
