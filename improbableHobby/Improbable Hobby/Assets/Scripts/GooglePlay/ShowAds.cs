using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAds : MonoBehaviour
{
    // Start is called before the first frame update

    public void Banner()
    {
        AdManager.RequestBanner();
    }

    public void LoadInterstitial()
    {
        AdManager.RequestInterstital();
    }

    public void ShowInterstitial()
    {
        AdManager.DisplayInterstitial();
    }

    public void LoadReward()
    {
        AdManager.RequestReward();
    }

    public void ShowReward()
    {
        AdManager.DisplayRewardAD();
    }


}
