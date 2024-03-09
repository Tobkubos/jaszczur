using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    private NumberConverter NumberConverter;
    public float price=0;
    public float priceChange = 1.01f;
    public float bonus=0;
	public float bonusChange = 1f;
    public int lvl = 0;
    
	private int[] tab = new int[5];
    private int i = 0;

    public GameObject buyButton;
    public TextMeshProUGUI buyCount;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI bonusText;
    public TextMeshProUGUI NAME;
    public TextMeshProUGUI BONUS;
	public GameObject[] stars;

    public string UpgradeName;
    public string UpgradeBonus;

    private ClickManager Manager;
    private void Start()
    {
        NumberConverter = GetComponent<NumberConverter>();
        Manager = GameObject.Find("GameManager").GetComponent<ClickManager>();

        //Start config text/price/bonus
        NAME.text = UpgradeName;
        priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
        levelText.text = "lvl: " + lvl.ToString();
        bonusText.text = "+ "+bonus+" "+UpgradeBonus;

		tab[0] = 1;
		tab[1] = 10;
		tab[2] = 25;
		tab[3] = 50;
		tab[4] = 100;
	}
    private void Update()
    {
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

    public void changeBuyCount()
    {
        i++;
        if(i == 5)
        {
            i = 0;
        }
        buyCount.text = "x " + tab[i].ToString();
    }

	private void massUpgrade(float priceForUpgrades, float numOflvl)
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
			}
		}
	}

	public void buyUpgrade()
    {
		if(i == 0)
		{
			massUpgrade(price, 1);
		}

		if (i == 1)
		{
			massUpgrade(checkPrice(price, priceChange, 10), 10);
		}

		if (i == 2)
		{
			massUpgrade(checkPrice(price, priceChange, 25), 25);
		}

		if (i == 3)
		{
			massUpgrade(checkPrice(price, priceChange, 50), 50);
		}

		if (i == 4)
		{
			massUpgrade(checkPrice(price, priceChange, 100), 100);
		}

		//
		///      zrob skrypt z tablica wszystkich upgrade czyt. wynikow ktore trzeba dodac
		////     dodaj sume do odpowiedniej stat. 
		/////	 tutaj dodawaj to odpowiedniej komórki w tablicy, dodaj na gorze jaki to upgrade
		//////
		Manager.click = bonus;
		//////
		/////
		////
		///
		//

		priceText.text = "Cost: " + NumberConverter.FormatNumber(price);
		levelText.text = "lvl: " + lvl.ToString();
		bonusText.text = "+ " + bonus + " " + UpgradeBonus;
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
