using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAds : MonoBehaviour
{
    public static bool ad = false;

    void Start()
    {
        if (!ad) { 
            AdManager.RequestBanner();
            ad = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }





}
