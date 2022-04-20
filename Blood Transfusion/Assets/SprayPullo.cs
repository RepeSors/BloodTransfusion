using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPullo : MonoBehaviour
{
    public GameObject vesiEff;


    private void OnTriggerEnter(Collider other)
    {
        vesiEff.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        vesiEff.SetActive(false);
    }


}
