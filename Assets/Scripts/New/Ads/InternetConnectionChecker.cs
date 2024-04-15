using System.Collections;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class InternetConnectionChecker : MonoBehaviour
{
	NetworkReachability reachability;
	public GameObject StatusBanner;
	public GameObject Icon;
	public TextMeshProUGUI StatusInfo1;
	public TextMeshProUGUI StatusInfo2;
	public TextMeshProUGUI StatusInfo3;
	private string status;

	private void Start()
	{
		StatusInfo2.text = "";
		LeanTween.rotateAround(Icon, new Vector3(0, 0, 1), 360f, 0.5f).setLoopType(LeanTweenType.clamp).setRepeat(-1);
		StartCoroutine(CheckStatusInterval());
		float IconX = Icon.transform.localPosition.x;
        float Status1X = Icon.transform.localPosition.x;
        float Status2X = Icon.transform.localPosition.x;
        float Status3X = StatusInfo3.transform.localPosition.x;
    }

	IEnumerator CheckStatusInterval()
	{
		while (true)
		{
			yield return new WaitForSeconds(2f);
			StartCoroutine(CheckStatus());
		}
	}
	IEnumerator CheckStatus()
	{
		StatusBanner.SetActive(true);
		StatusBanner.transform.localPosition = Vector3.zero;
		yield return new WaitForSeconds(2f);
		reachability = Application.internetReachability;
		switch (reachability)
		{
			case NetworkReachability.NotReachable:
				status = "No Internet connection";
				
				// Tutaj mo¿esz wyœwietliæ odpowiednie komunikaty dla gracza lub podj¹æ inne dzia³ania
				break;
			case NetworkReachability.ReachableViaCarrierDataNetwork:
				status = "Connected to the Internet via mobile data network";
				break;
			case NetworkReachability.ReachableViaLocalAreaNetwork:
				status = "Connected to the Internet via Wi-Fi network";
				break;
		}

		if(status != "No Internet connection")
		{
            StatusInfo2.text = status;
            yield return new WaitForSeconds(1f);
            LeanTween.moveLocalX(Icon, -1000f, 1f);
            LeanTween.moveLocalX(StatusInfo1.gameObject, 1000f, 0.5f).setDelay(0.2f);
            LeanTween.moveLocalX(StatusInfo2.gameObject, -1000f, 0.5f).setDelay(0.4f);
            LeanTween.moveLocalX(StatusInfo3.gameObject, 1000f, 0.5f).setDelay(0.4f);
			LeanTween.value(StatusBanner, UpdateColorAlpha, 1f, 0f, 1f)
			.setOnComplete(() => {
				// Once the fade out is complete, deactivate the object
				StatusBanner.SetActive(false);
			});
		}
		else
		{
			StatusBanner.SetActive(true);
		}
	}

	void UpdateColorAlpha(float alpha)
	{
		// Get the renderer component of the object (assuming it has one)
		Renderer renderer = StatusBanner.GetComponent<Renderer>();
		if (renderer != null)
		{
			// Get the current color of the renderer
			Color currentColor = renderer.material.color;
			// Update the alpha component of the color
			currentColor.a = alpha;
			// Update the color of the renderer
			renderer.material.color = currentColor;
		}
		else
		{
			// If the object doesn't have a renderer, try to get the Image component (for UI objects)
			Image image = StatusBanner.GetComponent<Image>();
			if (image != null)
			{
				// Get the current color of the image
				Color currentColor = image.color;
				// Update the alpha component of the color
				currentColor.a = alpha;
				// Update the color of the image
				image.color = currentColor;
			}
			else
			{
				// If neither renderer nor Image component is found, log an error
				Debug.LogError("Object to fade must have a Renderer or Image component.");
			}
		}
	}
}