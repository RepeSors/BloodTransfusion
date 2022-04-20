using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] GameObject platform;
    public bool isDisinfected;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject == platform)
        {
            Debug.Log("jee");
            isDisinfected = true;
        }       
    }


}
