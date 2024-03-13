using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
	/// <summary>
	/// 
	/// WYSWIETLANIE CZY JEST DOESEPNY DANY UPGRADE
	/// 
	/// </summary>
	public GameObject[] ClickUpgrades;
    public GameObject[] IdleUpgrades;
    public GameObject[] MultiplierUpgrades;
    public GameObject[] OtherUpgrades;

    public ClickManager ClickManager;

	private void Start()
	{
        ShowUpgradesPerLevel();   
    }

    public void FUNCTION_TotalCashPerClick()
    {
        float TotalCashPerClick = 1;
        for (int i = 0; i < ClickUpgrades.Length - 2; i++)
        {
            TotalCashPerClick += ClickUpgrades[i].GetComponent<UpgradeInfo>().bonus;
        }
        ClickManager.click = TotalCashPerClick;

    }
    public void ShowUpgradesPerLevel()
    {
        //CLICK
        for (int i = 0; i < ClickUpgrades.Length; i++)
        {
            ClickUpgrades[i].SetActive(false);
        }
        ClickUpgrades[0].SetActive(true);

        //IDLE
        for (int i = 0; i < IdleUpgrades.Length; i++)
        {
            IdleUpgrades[i].SetActive(false);
        }
        IdleUpgrades[0].SetActive(true);

        //MULTIPLIER
        for (int i = 0; i < MultiplierUpgrades.Length; i++)
        {
            MultiplierUpgrades[i].SetActive(false);
        }
        MultiplierUpgrades[0].SetActive(true);

        //OTHER
        for (int i = 0; i < OtherUpgrades.Length; i++)
        {
            OtherUpgrades[i].SetActive(false);
        }
        OtherUpgrades[0].SetActive(true);
    }
	private void Update()
	{
		EnableClickUpgrade();
        EnableIdleUpgrade();
        EnableMultiplierUpgrade();
        EnableOtherUpgrade();
	}

	private void EnableClickUpgrade()
	{
		for(int i = 0; i < ClickUpgrades.Length-2; i++) {
			if (ClickUpgrades[i].GetComponent<UpgradeInfo>().lvl > 10)
			{
				ClickUpgrades[i+1].SetActive(true);
			}
		}
	}

    private void EnableIdleUpgrade()
    {
        for (int i = 0; i < IdleUpgrades.Length - 2; i++)
        {
            if (IdleUpgrades[i].GetComponent<UpgradeInfo>().lvl > 10)
            {
                IdleUpgrades[i + 1].SetActive(true);
            }
        }
    }

    private void EnableMultiplierUpgrade()
    {
        for (int i = 0; i < MultiplierUpgrades.Length - 2; i++)
        {
            if (MultiplierUpgrades[i].GetComponent<UpgradeInfo>().lvl > 10)
            {
                MultiplierUpgrades[i + 1].SetActive(true);
            }
        }
    }

    private void EnableOtherUpgrade()
    {
        for (int i = 0; i < OtherUpgrades.Length - 2; i++)
        {
            if (OtherUpgrades[i].GetComponent<UpgradeInfo>().lvl > 10)
            {
                OtherUpgrades[i + 1].SetActive(true);
            }
        }
    }
}
