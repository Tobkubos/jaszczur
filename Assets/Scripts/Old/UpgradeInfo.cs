using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
	/// <summary>
	/// 
	/// WSZYSTKO O UPGRADE
	/// 
	/// </summary>

	[Header("START DATA")]
	public float start_price;
    public float start_bonus;

    [Header("DATA")]
    public int lvl;
    public float bonus;
	public float price;
    public float priceChange = 1.01f;
	public float bonusChange = 1f;

    [Header("SCENE")]
    public GameObject buyButton;
    public TextMeshProUGUI buyCount;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI TotalbonusText;
    public TextMeshProUGUI NAME;
	public GameObject[] stars;

    [Header("TEXT")]
    public string UpgradeName;
    public string UpgradeBonus;

    [Header("TYPE OF UPGRADE")]
    public bool clickUpgrade;
	public bool idleUpgrade;
	public bool MultiplierUpgrade;

    [Header("OTHER")]
    private NumberConverter NumberConverter;
    private ClickManager Manager;
	private UpgradeManager UpgradeManager;

	[Header("BUY STAGES")]
    private int[] tab = new int[5];
    private int i = 0;

    private void Start()
    {
        NumberConverter = GetComponent<NumberConverter>();
        Manager = GameObject.Find("GameManager").GetComponent<ClickManager>();
		UpgradeManager = GameObject.Find("GameManager").GetComponent<UpgradeManager>();

		//Start config text/price/bonus
		NAME.text = UpgradeName;
        priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
        levelText.text = "lvl: " + lvl.ToString();
        bonusText.text = "+ "+bonusChange+" "+UpgradeBonus;
		TotalbonusText.text = bonus + " " + UpgradeBonus; 
		CheckStars();

		tab[0] = 1;
		tab[1] = 10;
		tab[2] = 25;
		tab[3] = 50;
		tab[4] = 100;
	}
    private void Update()
    {
        priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
        levelText.text = "lvl: " + lvl.ToString();
        bonusText.text = "+ " + bonusChange + " " + UpgradeBonus;
        TotalbonusText.text = bonus + " " + UpgradeBonus;

        if (i != null)
		{
			//1 UPGRADE
			if (i == 0)
			{
				priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
				if (Manager.Cash < price)
				{
					buyButton.GetComponent<Image>().color = Color.red;
				}
				else
				{
					buyButton.GetComponent<Image>().color = Color.green;
				}
			}

			//10 UPGRADE
			if (i == 1)
			{
				float priceX10 = checkPrice(price, priceChange, 10);

				priceText.text = "Cost: " + NumberConverter.FormatNumber(priceX10);
				if (Manager.Cash < priceX10)
				{
					buyButton.GetComponent<Image>().color = Color.red;
				}
				else
				{
					buyButton.GetComponent<Image>().color = Color.green;
				}
			}

			//25 UPGRADE
			if (i == 2)
			{
				float priceX25 = checkPrice(price, priceChange, 25);

				priceText.text = "Cost: " + NumberConverter.FormatNumber(priceX25);
				if (Manager.Cash < priceX25)
				{
					buyButton.GetComponent<Image>().color = Color.red;
				}
				else
				{
					buyButton.GetComponent<Image>().color = Color.green;
				}
			}

			//50 UPGRADE
			if (i == 3)
			{
				float priceX50 = checkPrice(price, priceChange, 50);

				priceText.text = "Cost: " + NumberConverter.FormatNumber(priceX50);
				if (Manager.Cash < priceX50)
				{
					buyButton.GetComponent<Image>().color = Color.red;
				}
				else
				{
					buyButton.GetComponent<Image>().color = Color.green;
				}
			}

			//100 UPGRADE
			if (i == 4)
			{
				float priceX100 = checkPrice(price, priceChange, 100);

				priceText.text = "Cost: " + NumberConverter.FormatNumber(priceX100);
				if (Manager.Cash < priceX100)
				{
					buyButton.GetComponent<Image>().color = Color.red;
				}
				else
				{
					buyButton.GetComponent<Image>().color = Color.green;
				}
			}

		}
	}

    public void ChangeBuyCount()
    {
        i++;
        if(i == 5)
        {
            i = 0;
        }
        buyCount.text = "x " + tab[i].ToString();
    }

	private void MassUpgrade(float priceForUpgrades, float numOflvl)
	{
		if (Manager.Cash >= priceForUpgrades)
		{
			Manager.Cash -= priceForUpgrades;
			for(int j = 0; j< numOflvl; j++) 
			{
				bonus += bonusChange;
				price *= priceChange;
				lvl += 1;
				CheckStars();
				if (clickUpgrade == true)
				{
					UpgradeManager.FUNCTION_TotalCashPerClick();
				}

                if (idleUpgrade == true)
                {
                    UpgradeManager.FUNCTION_TotalIdleIncome();
                }
            }
		}
	}

	public void BuyUpgrade()
    {
		if(i == 0)
		{
			MassUpgrade(price, 1);
		}

		if (i == 1)
		{
			MassUpgrade(checkPrice(price, priceChange, 10), 10);
		}

		if (i == 2)
		{
			MassUpgrade(checkPrice(price, priceChange, 25), 25);
		}

		if (i == 3)
		{
			MassUpgrade(checkPrice(price, priceChange, 50), 50);
		}

		if (i == 4)
		{
			MassUpgrade(checkPrice(price, priceChange, 100), 100);
		}


		priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
		levelText.text = "lvl: " + lvl.ToString();
		bonusText.text = "+ " + bonusChange + " " + UpgradeBonus;
        TotalbonusText.text = bonus + " " + UpgradeBonus;
    }

	private float checkPrice(float price, float change ,int numb)
    {
        float newPrice = 0;
        newPrice = price * ((Mathf.Pow(change, numb) - 1) / (change - 1));
        return newPrice;
    }

	private void CheckStars()
	{
		if (lvl <= 100 && lvl % 10 == 0)
		{
			int index = lvl / 10 - 1;
			if (index >= 0 && index < stars.Length)
			{
				stars[index].gameObject.GetComponent<Image>().color = Color.yellow;
			}
		}

		if (lvl > 100 && lvl <= 200 && lvl % 10 == 0)
		{
			int index = lvl / 10 - 11;
			if (index >= 0 && index < stars.Length)
			{
				stars[index].gameObject.GetComponent<Image>().color = Color.red;
			}
		}
	}
}
