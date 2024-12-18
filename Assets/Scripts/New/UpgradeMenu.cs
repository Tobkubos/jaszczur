using System.Collections;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public Storage Storage;
    private bool CanClick = true;
    private bool CLICKED = false;
    private GameObject canvas;
    private void Start()
    {
        canvas = GameObject.FindWithTag("canvas");
        Storage.UpgradesMenu.transform.localPosition = new Vector3(0, -canvas.GetComponent<RectTransform>().rect.height, 0);
        EnableUpgrade(Storage.ClickUpgrades);
        EnableUpgrade(Storage.IdleUpgrades);
        EnableUpgrade(Storage.MultiplierUpgrades);
        EnableUpgrade(Storage.PrestigeUpgrades);

		Storage.LIST_ClickUpgrades.SetActive(true);
		Storage.LIST_IdleUpgrades.SetActive(false);
		Storage.LIST_MultiplierUpgrades.SetActive(false);
		Storage.LIST_OtherUpgrades.SetActive(false);
        Storage.PrestigeBox.SetActive(false);

        
	}

    private void Update()
    {
        canvas = GameObject.FindWithTag("canvas");
        CheckForUpgrade(Storage.ClickUpgrades);
        CheckForUpgrade(Storage.IdleUpgrades);
        CheckForUpgrade(Storage.MultiplierUpgrades);
    }
    public void ShowUpgrades()
    {
        if (CanClick == true)
        {
            CanClick = false;

            if (CLICKED == false)
            {
                Show();
            }
            else if (CLICKED == true)
            {
                Close();
            }
        }
    }

    public void Show()
    {
        CLICKED = true;
        StartCoroutine(Cooldown());
        LeanTween.moveLocalY(Storage.UpgradesMenu, -canvas.GetComponent<RectTransform>().rect.height / 3, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }

    public void Close()
    {
        CLICKED = false;
        StartCoroutine(Cooldown());
        LeanTween.moveLocalY(Storage.UpgradesMenu, -canvas.GetComponent<RectTransform>().rect.height, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanClick = true;
    }

    public void UpgradeMenuClicked()
    {
        Storage.PrestigeBox.SetActive(false);
        Storage.ALLUpgradeButtons.SetActive(true);
        ShowClickUpgrades();
    }

    public void PrestigeBoxClicked()
    {
        Storage.ALLUpgradeButtons.SetActive(false);
        ShowPrestigeBox();
    }

    public void ShowClickUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(true);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(false);
        Storage.PrestigeBox.SetActive(false);
    }
    public void ShowIdleUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(true);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(false);
        Storage.PrestigeBox.SetActive(false);
    }
    public void ShowMultiplierUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(true);
        Storage.LIST_OtherUpgrades.SetActive(false);
        Storage.PrestigeBox.SetActive(false);
    }
    public void ShowOtherUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(true);
        Storage.PrestigeBox.SetActive(false);
    }

    public void ShowPrestigeBox()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(false);
        Storage.PrestigeBox.SetActive(true);
    }
    private void CheckForUpgrade(GameObject[] tab)
    {
        for (int i = 0; i < tab.Length - 1; i++)
        {
            if (tab[i].GetComponent<Upgrade>().UPGRADE_Level > 10)
            {
                tab[i + 1].SetActive(true);
            }
        }
    }
    public void EnableUpgrade(GameObject[] tab)
    {
        for(int i=0; i<tab.Length; i++)
        {
            tab[i].SetActive(false);
        }
        tab[0].SetActive(true);
    }
}
