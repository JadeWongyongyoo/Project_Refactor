using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Restart : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    private int currentLevel;
    [SerializeField] string _androidAdUnitId = "Inerstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    void Awake()
    {
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        LoadAd();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowAd();
            SceneManager.LoadScene(currentLevel);
        }
    }
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {

    }
    public void OnUnityAdsAdLoaded(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Eror loading Ad Unit: {adUnitId}-{error.ToString()}-{message}");
    }
    public void OnUnityAdsShowFailure (string adUnitld, UnityAdsShowError error, string message)
    {
        Debug.Log($"Eror showing Ad Unit {adUnitld} : {error.ToString()}-{message}");
    }
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
