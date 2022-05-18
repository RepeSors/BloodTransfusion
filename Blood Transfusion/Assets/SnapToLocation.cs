using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Oculus.Interaction
{
    public class SnapToLocation : MonoBehaviour
    {
        public bool grabbed;

        public bool insideSnapZone;

        public bool Snapped;

        public float targetTime = 0f;

        public GameObject KiinnikeOsa;
        public GameObject SnapRotationReference;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == KiinnikeOsa.name)
            {
                insideSnapZone = true;
            }

            //Voice line tähän
            else if (other.gameObject.CompareTag("WrongLine"))
            {

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
            //targetTime += Time.fixedDeltaTime;

            if (!grabbed && insideSnapZone)
            {
                //targetTime = 0;
                KiinnikeOsa.transform.parent = SnapRotationReference.transform;
                KiinnikeOsa.gameObject.transform.position = transform.position;
                KiinnikeOsa.gameObject.transform.rotation = SnapRotationReference.transform.rotation;
                Snapped = true;
            }

            /*else if (grabbed && insideSnapZone && Snapped)
            {
                Debug.Log("Tää Lähti Käyntiin!");
                if (targetTime >= 2f)
                {
                    KiinnikeOsa.transform.parent = null;
                    Snapped = false;
                    targetTime = 0;
                }
            }

            if (Snapped == false)
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
            }*/
            

        }



        // Update is called once per frame
        void FixedUpdate()
        {
            grabbed = KiinnikeOsa.GetComponent<PhysicsGrabbable>().grabbed;
            SnapObject();
        }
    }
}

