using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using TMPro;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	public Storage Storage;
	[SerializeField] Button _showAdButton;
	[SerializeField] string _androidAdUnitId = "Rewarded_Android";
	[SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
	string _adUnitId = null; // This will remain null for unsupported platforms

	public GameObject RewardedAddBanner;
	public TextMeshProUGUI TEXT_Reward;
	double Bonus = 0;

	void Awake()
	{
		// Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
		_adUnitId = _androidAdUnitId;
#endif

		// Disable the button until the ad is ready to show:
		_showAdButton.interactable = false;
	}

	// Call this public method when you want to get an ad ready to show.
	public void LoadAd()
	{
		// IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
		Debug.Log("Loading Ad: " + _adUnitId);
		Advertisement.Load(_adUnitId, this);
		RewardedAddBanner.SetActive(true);
		RewardedAddBanner.transform.localPosition = new Vector3(0, 0, 0);

		if (Storage.val_CashPerSec > 0)
		{
			Bonus = Storage.val_CashPerSec * 2700;
		}
		else
		{
			Bonus = Storage.val_CashPerClick * 1000;
		}
		TEXT_Reward.text = Bonus.ToString();
		Debug.Log("przed"+Bonus);
	}

	public void CloseBanner()
	{
		RewardedAddBanner.SetActive(false);
	}

	// If the ad successfully loads, add a listener to the button and enable it:
	public void OnUnityAdsAdLoaded(string adUnitId)
	{
		Debug.Log("Ad Loaded: " + adUnitId);

		if (adUnitId.Equals(_adUnitId))
		{
			// Configure the button to call the ShowAd() method when clicked:
			_showAdButton.onClick.AddListener(ShowAd);
			// Enable the button for users to click:
			_showAdButton.interactable = true;
		}
	}

	// Implement a method to execute when the user clicks the button:
	public void ShowAd()
	{
		// Disable the button:
		_showAdButton.interactable = false;
		// Then show the ad:
		Advertisement.Show(_adUnitId, this);
	}

	// Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
	public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
	{
		if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
		{
			Debug.Log("Unity Ads Rewarded Ad Completed");
			Debug.Log("po" + Bonus);
			Storage.val_TotalCash += Bonus;
			Bonus = 0;
		}

		RewardedAddBanner.SetActive(false);
	}

	// Implement Load and Show Listener error callbacks:
	public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
	{
		Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
		// Use the error details to determine whether to try to load another ad.
	}

	public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
	{
		Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
		// Use the error details to determine whether to try to load another ad.
	}

	public void OnUnityAdsShowStart(string adUnitId) { }
	public void OnUnityAdsShowClick(string adUnitId) { }

	void OnDestroy()
	{
		// Clean up the button listeners:
		_showAdButton.onClick.RemoveAllListeners();
	}
}