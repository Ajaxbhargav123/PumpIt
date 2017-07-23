using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using admob;

public class AdsManeger : MonoBehaviour {
    public static AdsManeger Instant { set; get; }
    public string BannerId;
    public string IntrestialId;


    private void Start () {
        Instant = this;
        DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(BannerId,IntrestialId);
       
        Admob.Instance().loadInterstitial();
#endif
    }

    public void ShowBanner()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.TOP_CENTER, 5);
#endif
    }

    public void ShowIntrestial()
    {
#if UNITY_EDITOR
#elif UNITY_ANDROID
      
        Admob.Instance().showInterstitial();
#endif
    }


}
