using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlowScript : MonoBehaviour
{
    [SerializeField] GameObject wateR;
    public bool isActivated;


    public void WaterGo()
    {
        wateR.SetActive(true);
    }

    public void WaterOff()
    {
        wateR.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
