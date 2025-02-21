using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerReklami : MonoBehaviour
{
//ca-app-pub-3940256099942544/6300978111
#if UNITY_EDITOR
    string _adUnitID = "ca-app-pub-4239141501894599/3865423540";
#elif UNITY_IPHONE
        string _adUnitID = "ca-app-pub-3940256099942544/2934735716";
#else
        string _adUnitID = "unused";
#endif

    BannerView _Banner;
    void Start()
    {

        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });
        BannerYukle();
    }

    void BannerOlustur()
    {
        if (_Banner != null)
        {
            _Banner.Destroy();
            _Banner = null;
        }

        //_Banner = new BannerView(_adUnitID, AdSize.Banner,0,50); // yöntem 1
        // _Banner = new BannerView(_adUnitID, AdSize.Banner,AdPosition.Bottom); // yöntem 2

        AdSize Adsize = new(320,50);
        _Banner = new BannerView(_adUnitID, Adsize, AdPosition.Bottom); // yöntem 3
    }

    void BannerYukle()
    {
        if (_Banner == null)
        {
            BannerOlustur();

            var _AdRequest = new AdRequest.Builder().Build();

            _Banner.LoadAd(_AdRequest);
            ReklamOlaylariniDinle();
        }

    }

    void ReklamOlaylariniDinle()
    {
        _Banner.OnBannerAdLoaded += () =>
        {
            Debug.Log("banner Yüklendi");

        };
        _Banner.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.Log("Banner Yüklenemedi. HATA : " + error);
           // BannerYukle();
        };
    }

}
