using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SnapToLocation : MonoBehaviour
{
    public bool grabbed;

    private bool insideSnapZone;

    public bool Snapped;

    public float targetTime = 10f;

    public GameObject KiinnikeOsa;
    public GameObject SnapRotationReference;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == KiinnikeOsa.name)
        {
            insideSnapZone = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == KiinnikeOsa.name)
        {
            insideSnapZone = false;
        }
    }

    void SnapObject()
    {
        if (!grabbed && insideSnapZone)
        {
            KiinnikeOsa.transform.parent = SnapRotationReference.transform;
            KiinnikeOsa.gameObject.transform.position = transform.position;
            KiinnikeOsa.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }

        /*if (Snapped == false)
        {
            if (!grabbed && insideSnapZone)
            {
                KiinnikeOsa.gameObject.transform.position = transform.position;
                KiinnikeOsa.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
                targetTime -= Time.deltaTime;
                if (targetTime <= 0.0f)
                {
                    SnapRotationReference.SetActive(true);
                    Snapped = true;
                }
                
            }
        }
        else if(!grabbed && Snapped == true)
        {
            Debug.Log("Tää Lähti Käyntiin!");
            targetTime += Time.deltaTime;
            if (targetTime >= 20f)
            {
                SnapRotationReference.SetActive(false);
                Snapped = false;
            }
            
            
        }*/

    }


    // Update is called once per frame
    void Update()
    {
        grabbed = KiinnikeOsa.GetComponent<GrabDetection>().isGrabbed;
        SnapObject();
    }
}
