using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GecisReklami : MonoBehaviour
{
    

#if UNITY_EDITOR
    string _adUnitID = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string _adUnitID = "ca-app-pub-3940256099942544/4411468910";
#else
        string _adUnitID = "unused";
#endif

    InterstitialAd _GecisReklami;

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            
        });
        GecisReklamiOlustur();
    }

    void GecisReklamiOlustur()
    {
        if (_GecisReklami !=null)
        {
            _GecisReklami.Destroy();
            _GecisReklami = null;
        }       

        var _AdRequest = new AdRequest.Builder().Build();

        InterstitialAd.Load(_adUnitID, _AdRequest,
            (InterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad==null) {

                    Debug.LogError("Reklam yüklenirken hata oluþtu HATA : " + error);
                    return;
                }

                _GecisReklami = Ad;

            });

        ReklamOlaylariniDinle(_GecisReklami);
    }


    void ReklamOlaylariniDinle(InterstitialAd ad)
    {
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Ödüllü Reklam {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };

        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Geçiþ reklamý bir gösterim kaydetti.");
        };

        ad.OnAdClicked += () =>
        {
            Debug.Log("Geçiþ reklamý týklandý.");
        };

        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Geçiþ reklamý tam ekran açýldý.");
        };

        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Geçiþ reklamý kapatýldý.");
            GecisReklamiOlustur();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.Log("Geçiþ reklamý açýlamadý. HATA : " + error);
            GecisReklamiOlustur();
        };
    }

    public void GecisReklamiGoster()
    {

        if (_GecisReklami != null && _GecisReklami.CanShowAd())
        {           
            _GecisReklami.Show();
            Debug.Log("reklam gösterildi");
        }
        else
        {
            Debug.Log("Geçiþ reklamý henüz hazýr deðil");
        }

    }

    void ReklamiOldur()
    {
        _GecisReklami.Destroy();
    }
    
}
