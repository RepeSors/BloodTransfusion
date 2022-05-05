using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaaLuukku : MonoBehaviour
{
    [SerializeField] private Animator avaaLuukku;

    [SerializeField] private string onAuki = "onAuki";
    [SerializeField] private string onKiinni = "onKiinni";
    public bool kiinni;

    public void LuukkuAnimaatio()
    {
        if (kiinni == false)
        {
            avaaLuukku.Play(onAuki, 0, 0.0f);
            kiinni = true;
        }
        else
        {
            avaaLuukku.Play(onKiinni, 0, 0.0f);
        }
        
    }

    /*public void LuukkuAnimaatioKiinni()
    {
        avaaLuukku.Play(onKiinni, 0, 0.0f);
    }*/

}
