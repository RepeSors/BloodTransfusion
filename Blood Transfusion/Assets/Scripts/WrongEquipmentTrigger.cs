using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongEquipmentTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        //Voice line tähän
        if (other.gameObject.CompareTag("WrongLine"))
        {

        }

        //Voice line tähän
        else if (other.gameObject.CompareTag("CorrectLine"))
        {

        }
    }
}
