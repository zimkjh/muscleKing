using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class Test : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    void Start()
    {
#if UNITY_ANDROID
    string appId = "ca-app-pub-8642591281586798~7925257757";
#else
    string appId = "unexpected_platform";
#endif
    MobileAds.Initialize(appId);
    RequestInterstitial();
    }
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
    string adUnitId = "ca-app-pub-8642591281586798/9277373039";
#else 
    string adUnitId = "unexpected_platform";
#endif

    this.interstitial = new InterstitialAd(adUnitId);
    // Called when an ad request has successfully loaded.
    this.interstitial.OnAdLoaded += HandleOnAdLoaded;
    // Called when an ad request failed to load.
    this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
    // Called when an ad is shown.
    this.interstitial.OnAdOpening += HandleOnAdOpened;
    // Called when the ad is closed.
    this.interstitial.OnAdClosed += HandleOnAdClosed;
    // Called when the ad click caused the user to leave the application.
    this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    // Create an empty ad request.
    AdRequest request = new AdRequest.Builder().Build();
    // Load the interstitial with the request.
    this.interstitial.LoadAd(request);
 
        
 
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }
 
    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }
 
    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }
 
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }
 
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    public void AdsShow()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            RequestInterstitial();
        }
    }
}
