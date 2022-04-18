using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Grab;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.HandPosing;

public class GrabDetection : MonoBehaviour
{
    public bool isGrabbed;
    public bool insideSnapZone;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isKinematic && insideSnapZone == false)
        {
            Debug.Log("grabbed");
            isGrabbed = true;
        }

        if (!rb.isKinematic)
        {
            isGrabbed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            rb.isKinematic = false;
            insideSnapZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        rb.isKinematic = true;
        insideSnapZone = false;
    }

}
