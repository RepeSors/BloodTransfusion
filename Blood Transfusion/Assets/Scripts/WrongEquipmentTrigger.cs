using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongEquipmentTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        //Voice line t�h�n
        if (other.gameObject.CompareTag("WrongLine"))
        {

        }

        //Voice line t�h�n
        else if (other.gameObject.CompareTag("CorrectLine"))
        {

        }
    }
}
