using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;

/**
 * To request put a banner on bottom of the screen
 * Call RequestBanner() and it will show when loaded automatically like 1 sec
 * To put interstitial
 * Call DisplayInterstitial() Ad should alread be loaded unless another call in less than like 2 seconds after first one was closed
 * To call reward ad
 * Call DisplayRewardAd() Ad will reward the player 50 coins
 * 
 */

public class AdManager : MonoBehaviour
{

    private static string AppId = "ca-app-pub-3181861234105818~5201905736";
    private static BannerView banner;
    public static List<BannerView> banners;
    private static InterstitialAd interstitial;
    private static RewardedAd reward;

    void Start()
    {
        MobileAds.Initialize(AppId);
        banners = new List<BannerView>();
    }



    public static void RequestBanner()
    {
        
        string bannerId = "ca-app-pub-3940256099942544/6300978111";
        //string bannerId = "ca-app-pub-3181861234105818/4188206964";  
        banner = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Bottom);
        // Called when an ad request has successfully loaded.
        banner.OnAdLoaded += HandleOnAdLoaded2;
        // Called when an ad request failed to load.
        banner.OnAdFailedToLoad += HandleOnAdFailedToLoad2;
        // Called when an ad is clicked.
        banner.OnAdOpening += HandleOnAdOpened2;
        // Called when the user returned from the app after an ad click.
        banner.OnAdClosed += HandleOnAdClosed2;
        // Called when the ad click caused the user to leave the application.
        banner.OnAdLeavingApplication += HandleOnAdLeavingApplication2;

        AdRequest request = new AdRequest.Builder().
            AddTestDevice("ca-app-pub-3940256099942544/6300978111"). //remove when done testing
            Build();

        banner.LoadAd(request);
        
    }


    public static void HandleOnAdLoaded2(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
        DisplayBanner();
    }

    public static void HandleOnAdFailedToLoad2(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public static void HandleOnAdOpened2(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
        banner.Destroy();
    }

    public static void HandleOnAdClosed2(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        banner.Destroy();
    }

    public static void HandleOnAdLeavingApplication2(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
        banner.Destroy();
    }







    public static void RequestInterstital()
    {
        
        string id = "ca-app-pub-3940256099942544/1033173712";
        //string id = "ca-app-pub-3181861234105818/2380919820";  
        interstitial = new InterstitialAd(id);

        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().
            //AddTestDevice("ca-app-pub-3940256099942544/6300978111"). //remove when done testing
            Build();

        interstitial.LoadAd(request);
    }

    public static void HandleOnAdLeavingApplication(object sender, EventArgs e)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
        
    }

    public static void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");

    }

    public static void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public static void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public static void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        interstitial.Destroy();
        RequestInterstital();
    }













    public static void RequestReward()
    {
        string id = "ca-app-pub-3940256099942544/5224354917";
        //string id = "ca-app-pub-3181861234105818/3965464230";  
        reward = new RewardedAd(id);

        // Called when an ad request has successfully loaded.
        reward.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        reward.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        reward.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        reward.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        reward.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        reward.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().
            AddTestDevice("ca-app-pub-3940256099942544/6300978111"). //remove when done testing
            Build();

        reward.LoadAd(request);
    }


    public static void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public static void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public static void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public static void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public static void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestReward();
    }

    public static void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) + 50);
    }

    


    
    //change the 0's to 1's once testing is done
    public static void DisplayBanner()
    {
        if (PlayerPrefs.GetInt("Ads", 0) == 0)
        {
            banner.Show();
        }
    }

    public static void DisplayInterstitial()
    {
        if (interstitial != null)
        {
            if (interstitial.IsLoaded() && PlayerPrefs.GetInt("Ads", 0) == 0)
            {
                interstitial.Show();
            }
        }
    }

    public static void DisplayRewardAD()
    {
        if (reward.IsLoaded() && PlayerPrefs.GetInt("Ads", 0) == 0)
        {
            reward.Show();
        }
    }


    public static void DestroyBanner()
    {
        if (banner != null)
        {
            banner.Destroy();
        }
    }

    public static void DestroyIntersitial()
    {
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
    }






}
