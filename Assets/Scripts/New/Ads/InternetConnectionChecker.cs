using System.Collections;
using TMPro;
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
        StatusBanner.transform.localPosition = Vector3.zero;
    }

    IEnumerator CheckStatusInterval()
    {
        StartCoroutine(CheckStatus());
        yield return new WaitForSeconds(3.5f);
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            StartCoroutine(CheckStatus());
        }
    }

    IEnumerator CheckStatus()
    {
        yield return new WaitForSeconds(2f);
        reachability = Application.internetReachability;
        switch (reachability)
        {
            case NetworkReachability.NotReachable:
                status = "No Internet connection";
                StatusBanner.SetActive(true); // Aktywuj StatusBanner tylko w przypadku braku po³¹czenia
                break;
            case NetworkReachability.ReachableViaCarrierDataNetwork:
                status = "Connected to the Internet via mobile data network";
                break;
            case NetworkReachability.ReachableViaLocalAreaNetwork:
                status = "Connected to the Internet via Wi-Fi network";
                break;
        }
        StatusInfo2.text = status;

        if (status != "No Internet connection")
        {
            if (StatusBanner.activeSelf)
            {
                float tick = 1.2f;
                LeanTween.moveLocalY(Icon, -1500f, tick).setEase(LeanTweenType.easeInBack);
                LeanTween.moveLocalY(StatusInfo1.gameObject, -1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.2f);
                LeanTween.moveLocalY(StatusInfo2.gameObject, -1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.3f);
                LeanTween.moveLocalY(StatusInfo3.gameObject, -1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.1f);
                StatusBanner.GetComponent<Image>().color = new Color(0.14f, 0.14f, 0.14f, 1);

                yield return new WaitForSeconds(1f);
                LeanTween.moveLocalY(Icon, 1500f, tick).setEase(LeanTweenType.easeInBack);
                LeanTween.moveLocalY(StatusInfo1.gameObject, 1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.2f);
                LeanTween.moveLocalY(StatusInfo2.gameObject, 1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.3f);
                LeanTween.moveLocalY(StatusInfo3.gameObject, 1500f, tick).setEase(LeanTweenType.easeInBack).setDelay(0.1f);
                LeanTween.value(StatusBanner, UpdateColorAlpha, 1f, 0f, 3f)
                .setOnComplete(() =>
                {
                    // Once the fade out is complete, deactivate the object
                    StatusBanner.SetActive(false);
                });
            }
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
