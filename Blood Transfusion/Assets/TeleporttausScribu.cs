using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using OculusSampleFramework;

public class TeleporttausScribu : MonoBehaviour
{
    public bool isAtDestOne = false;
    [SerializeField] public GameObject player_rig;
    [SerializeField] public GameObject destination, destination2;
    
    void Start()
    {
        
    }

    public void Teleporttaus() //<-- InteractableStateArgs state
    {
        player_rig.transform.position = destination.transform.position;
        
    }

    public void Teleporttauskaksi() 
    {
        player_rig.transform.position = destination2.transform.position;
        
    }

}
