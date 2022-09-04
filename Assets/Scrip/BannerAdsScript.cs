using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdsScript : MonoBehaviour
{
    [SerializeField] BannerPosition _bannerPostion = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOsAdUnitId = "Banner_ios";
    GameObject player;
    string _adUnitId;

    void Start()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
        Advertisement.Banner.SetPosition(_bannerPostion);
        player = GameObject.FindWithTag("Player");
        LoadBanner();
    }

    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerEror
        };
        Advertisement.Banner.Load(_adUnitId, options);
    }
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }
    void OnBannerEror(string message)
    {
        Debug.Log($"Banner Eror: {message}");
    }
    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        Advertisement.Banner.Show(_adUnitId, options);
    }
    void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    void OnBannerClicked() {
        HideBannerAd();
        player.GetComponent<Pickup>().IncreaseCoin(10);
    }
    void OnBannerHidden() { }
    void OnBannerShown() { }

    private void OnDestroy()
    {
        
    }
}
