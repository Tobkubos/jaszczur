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
    string _adUnitId = null; // Pozostanie null dla nieobs³ugiwanych platform

    void Awake()
    {
        // Pobierz identyfikator jednostki reklamowej dla bie¿¹cej platformy:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        // Wy³¹cz przycisk do momentu, gdy reklama bêdzie gotowa do pokazania:
        _showAdButton.interactable = true;
    }

    // Wywo³aj tê publiczn¹ metodê, gdy chcesz przygotowaæ reklamê do pokazania.
    public void LoadAd()
    {
        // WA¯NE! £aduj zawartoœæ TYLKO PO inicjalizacji (w tym przyk³adzie, inicjalizacja jest obs³ugiwana w innym skrypcie).
        Debug.Log("£adowanie reklamy: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
        OnUnityAdsAdLoaded(_adUnitId);
        ShowAd();

    }

    // Jeœli reklama zostanie pomyœlnie za³adowana, dodaj nas³uchiwacz do przycisku i w³¹cz go:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Reklama za³adowana: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Konfiguruj przycisk, aby wywo³ywa³ metodê ShowAd() po klikniêciu:
            _showAdButton.onClick.AddListener(ShowAd);
            // W³¹cz przycisk, aby u¿ytkownicy mogli klikn¹æ:
            _showAdButton.interactable = true;
        }
    }

    // Implementuj metodê ShowAd(), aby pokazaæ reklamê:
    public void ShowAd()
    {
        // Wy³¹cz przycisk:
        _showAdButton.interactable = false;
        // Poka¿ reklamê:
        Advertisement.Show(_adUnitId, this);
    }

    // Implementuj metodê OnUnityAdsShowComplete z listenera, aby okreœliæ, czy u¿ytkownik otrzymuje nagrodê:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Reklama nagrodowa zakoñczona");
            idle.Collect2X();
        }
    }

    // Implementuj b³êdy listenerów Load i Show:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"B³¹d ³adowania jednostki reklamowej {adUnitId}: {error.ToString()} - {message}");
        // Wykorzystaj szczegó³y b³êdu, aby okreœliæ, czy spróbowaæ za³adowaæ inn¹ reklamê.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"B³¹d wyœwietlania jednostki reklamowej {adUnitId}: {error.ToString()} - {message}");
        // Wykorzystaj szczegó³y b³êdu, aby okreœliæ, czy spróbowaæ za³adowaæ inn¹ reklamê.
    }

    // Implementuj puste metody, które nie s¹ wykorzystywane w tym skrypcie:
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Wyczyœæ nas³uchiwacze przycisku:
        _showAdButton.onClick.RemoveAllListeners();
    }
}