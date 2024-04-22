using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;

public class RewardedAdsIdle : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public Storage Storage;
    public Idle idle;
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    string _adUnitId = null; // Pozostanie null dla nieobs�ugiwanych platform

    void Awake()
    {
        // Pobierz identyfikator jednostki reklamowej dla bie��cej platformy:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Wy��cz przycisk do momentu, gdy reklama b�dzie gotowa do pokazania:
        _showAdButton.interactable = true;
    }

    // Wywo�aj t� publiczn� metod�, gdy chcesz przygotowa� reklam� do pokazania.
    public void LoadAd()
    {
        // WA�NE! �aduj zawarto�� TYLKO PO inicjalizacji (w tym przyk�adzie, inicjalizacja jest obs�ugiwana w innym skrypcie).
        Debug.Log("�adowanie reklamy: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
        OnUnityAdsAdLoaded(_adUnitId);
        ShowAd();

    }

    // Je�li reklama zostanie pomy�lnie za�adowana, dodaj nas�uchiwacz do przycisku i w��cz go:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Reklama za�adowana: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Konfiguruj przycisk, aby wywo�ywa� metod� ShowAd() po klikni�ciu:
            _showAdButton.onClick.AddListener(ShowAd);
            // W��cz przycisk, aby u�ytkownicy mogli klikn��:
            _showAdButton.interactable = true;
        }
    }

    // Implementuj metod� ShowAd(), aby pokaza� reklam�:
    public void ShowAd()
    {
        // Wy��cz przycisk:
        _showAdButton.interactable = false;
        // Poka� reklam�:
        Advertisement.Show(_adUnitId, this);
    }

    // Implementuj metod� OnUnityAdsShowComplete z listenera, aby okre�li�, czy u�ytkownik otrzymuje nagrod�:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Reklama nagrodowa zako�czona");
            idle.Collect2X();
        }
    }

    // Implementuj b��dy listener�w Load i Show:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"B��d �adowania jednostki reklamowej {adUnitId}: {error.ToString()} - {message}");
        // Wykorzystaj szczeg�y b��du, aby okre�li�, czy spr�bowa� za�adowa� inn� reklam�.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"B��d wy�wietlania jednostki reklamowej {adUnitId}: {error.ToString()} - {message}");
        // Wykorzystaj szczeg�y b��du, aby okre�li�, czy spr�bowa� za�adowa� inn� reklam�.
    }

    // Implementuj puste metody, kt�re nie s� wykorzystywane w tym skrypcie:
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Wyczy�� nas�uchiwacze przycisku:
        _showAdButton.onClick.RemoveAllListeners();
    }
}