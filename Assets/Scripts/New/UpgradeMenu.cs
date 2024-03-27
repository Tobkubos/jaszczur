using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public Storage Storage;
    private bool CanClick = true;
    private bool CLICKED = false;
    private void Start()
    {
        Storage.UpgradesMenu.transform.localPosition = new Vector3(0, -Storage.Canva.rect.height + 200, 0);
        EnableUpgrade(Storage.ClickUpgrades);
        EnableUpgrade(Storage.IdleUpgrades);
        EnableUpgrade(Storage.MultiplierUpgrades);

		Storage.LIST_ClickUpgrades.SetActive(true);
		Storage.LIST_IdleUpgrades.SetActive(false);
		Storage.LIST_MultiplierUpgrades.SetActive(false);
		Storage.LIST_OtherUpgrades.SetActive(false);
	}

    private void Update()
    {
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
                CLICKED = true;
                StartCoroutine(Cooldown());
                LeanTween.moveLocalY(Storage.UpgradesMenu, -Storage.Canva.rect.height / 3 - 200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
            }
            else if (CLICKED == true)
            {
                CLICKED = false;
                LeanTween.moveLocalY(Storage.UpgradesMenu, -Storage.Canva.rect.height + 200, 0.5f).setEase(LeanTweenType.easeInOutSine);
                StartCoroutine(Cooldown());
            }
        }
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanClick = true;
    }
    public void ShowClickUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(true);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(false);
    }
    public void ShowIdleUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(true);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(false);
    }
    public void ShowMultiplierUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(true);
        Storage.LIST_OtherUpgrades.SetActive(false);
    }
    public void ShowOtherUpgrades()
    {
        Storage.LIST_ClickUpgrades.SetActive(false);
        Storage.LIST_IdleUpgrades.SetActive(false);
        Storage.LIST_MultiplierUpgrades.SetActive(false);
        Storage.LIST_OtherUpgrades.SetActive(true);
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
