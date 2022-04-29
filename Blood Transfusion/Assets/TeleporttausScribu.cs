using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;

public class TeleporttausScribu : MonoBehaviour
{
    public bool isAtDestOne = false;
    [SerializeField] public GameObject player_rig;
    [SerializeField] public GameObject destination, destination2, destination_recovery, destination3, destination4, destination_start;
    
    void Start()
    {
        
    }

    public void Teleporttaus() //<-- InteractableStateArgs state
    {
        player_rig.transform.position = destination.transform.position;
        player_rig.transform.rotation = destination.transform.rotation;

    }

    public void Teleporttauskaksi() 
    {
        player_rig.transform.position = destination2.transform.position;
        player_rig.transform.rotation = destination2.transform.rotation;
    }

    public void Teleporttausrecovery()
    {
        player_rig.transform.position = destination_recovery.transform.position;
        player_rig.transform.rotation = destination_recovery.transform.rotation;
    }

    public void Teleporttauskolme()
    {
        player_rig.transform.position = destination3.transform.position;
        player_rig.transform.rotation = destination3.transform.rotation;
    }

    public void Teleporttausneljä()
    {
        player_rig.transform.position = destination4.transform.position;
        player_rig.transform.rotation = destination4.transform.rotation;
    }

    public void TeleporttausStart(bool state)
    {
        player_rig.transform.position = destination_start.transform.position;
        player_rig.transform.rotation = destination_start.transform.rotation;
    }

}
