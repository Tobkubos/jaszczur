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

	private void Start()
	{
		for(int i = 0; i< ClickUpgrades.Length; i++)
		{
			ClickUpgrades[i].SetActive(true);
		}
		ClickUpgrades[0].SetActive(true);
	}

	private void Update()
	{
		EnableClickUpgrade();
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
}
