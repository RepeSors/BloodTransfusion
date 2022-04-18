using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SnapToLocation : MonoBehaviour
{
    private bool grabbed;

    private bool insideSnapZone;

    public bool Snapped;

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
            KiinnikeOsa.gameObject.transform.position = transform.position;
            KiinnikeOsa.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        grabbed = KiinnikeOsa.GetComponent<GrabDetection>().isGrabbed;
        SnapObject();
    }
}
