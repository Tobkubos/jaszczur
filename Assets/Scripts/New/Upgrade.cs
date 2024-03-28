
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    Storage Storage;
    NumberConverter NumberConverter;

    public GameObject BUTTON_Buy;
    public GameObject BUTTON_Change;

    [Header("TEXT MESH PRO")]
    public string           STRING_NameOfUpgrade;
    public string           STRING_DescOfUpgrade;
    public TextMeshProUGUI  TEXT_NameOfUpgrade;
    public TextMeshProUGUI  TEXT_BonusChange;
    public TextMeshProUGUI  TEXT_Bonus;
    public TextMeshProUGUI  TEXT_Price;
    public TextMeshProUGUI  TEXT_Level;
    public TextMeshProUGUI  TEXT_BuyCount;

    [Header("START VALUES")]
    public int          START_Price;

    [Header("VALUES")]
    public int      UPGRADE_Level;
    public double   UPGRADE_Bonus;
    public double   UPGRADE_Price;
    public double   UPGRADE_BonusChange;
    public float    UPGRADE_PriceChange;

    [Header("TYPE")]
    public bool Click;
    public bool Idle;
    public bool Multiplier;

    public GameObject[] stars;

    private int[] tab = { 1,10,25,50,100};
    private int changer = 0;
    void Start()
    {
        Storage = GameObject.Find("GameManager").GetComponent<Storage>();


        if (UPGRADE_Level == 0) UPGRADE_Price = START_Price;
        NumberConverter = GetComponent<NumberConverter>();

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].GetComponent<Image>().color = Color.white;
        }
        CheckStars();

        TEXT_NameOfUpgrade.text = STRING_NameOfUpgrade;
        TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(UPGRADE_Price);
        TEXT_Level.text = "lvl: " + UPGRADE_Level.ToString();
        TEXT_Bonus.text = " + " + NumberConverter.FormatNumberfloat1(UPGRADE_Bonus) + " " + STRING_DescOfUpgrade;
        TEXT_BonusChange.text = " + " + UPGRADE_BonusChange + " " + STRING_DescOfUpgrade;
    }
    public void PriceChange()
    {
        changer++;
        if (changer == 5)
        {
            changer = 0;
        }
        TEXT_BuyCount.text = "x " + tab[changer].ToString();
    }

    public void CheckStars()
    {
		for (int i = 0; i < stars.Length; i++)
		{
			stars[i].GetComponent<Image>().color = Color.white;
		}

		int NumOfStars = UPGRADE_Level / 10;
        if(NumOfStars <= stars.Length)
        {
            for(int i =0; i<NumOfStars; i++)
            {
                stars[i].GetComponent<Image>().color = Color.cyan;
            }
        }
    }

    private void MassUpgrade(double priceForUpgrades, int numOflvl)
    {
        if (Storage.val_TotalCash >= priceForUpgrades)
        {
            Storage.val_TotalCash -= priceForUpgrades;
            for (int j = 0; j < numOflvl; j++)
            {
                UPGRADE_Bonus += UPGRADE_BonusChange;
                UPGRADE_Price *= UPGRADE_PriceChange;
                UPGRADE_Level += 1;
                CheckStars();
            }
            if (Click)
            {
                Storage.val_CashPerClick = 0;
                for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
                {
                    Storage.val_CashPerClick += Storage.ClickUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
                }
            }
            if (Idle)
            {
                Storage.val_CashPerSec = 0;
                for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
                {
                    Storage.val_CashPerSec += Storage.IdleUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
                }
            }
			if (Multiplier)
			{
				Storage.val_MaxMultiplier = 0;
				for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
				{
					Storage.val_MaxMultiplier += Storage.MultiplierUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
				}
			}
		}
    }

    public void BuyUpgrade()
    {
        if (changer == 0)
        {
            MassUpgrade(UPGRADE_Price, 1);
        }

        if (changer == 1)
        {
            MassUpgrade(checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 10), 10);
        }

        if (changer == 2)
        {
            MassUpgrade(checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 25), 25);
        }

        if (changer == 3)
        {
            MassUpgrade(checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 50), 50);
        }

        if (changer == 4)
        {
            MassUpgrade(checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 100), 100);
        }
    }

    private double checkPrice(double price, float change, int numb)
    {
        double newPrice = 0;
        newPrice = price * ((Mathf.Pow(change, numb) - 1) / (change - 1));
        return newPrice;
    }

   private void CanBuy(double price)
    {
        if (Storage.val_TotalCash < price)
        {
            BUTTON_Buy.GetComponent<Image>().color = Color.red;
        }
        else
        {
            BUTTON_Buy.GetComponent<Image>().color = Color.green;
        }
    }


    void Update()
    {
        TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(UPGRADE_Price);
        TEXT_Level.text = "lvl: " + UPGRADE_Level.ToString();
        TEXT_Bonus.text = " + " + UPGRADE_Bonus + " " + STRING_DescOfUpgrade;
        TEXT_BonusChange.text = " + " + UPGRADE_BonusChange + " " + STRING_DescOfUpgrade;

        if (changer != null)
        {
            //1 UPGRADE
            if (changer == 0)
            {
                TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(UPGRADE_Price);
                CanBuy(UPGRADE_Price);
            }

            //10 UPGRADE
            if (changer == 1)
            {
                double priceX10 = checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 10);
                TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(priceX10);
                CanBuy(priceX10);
            }

            //25 UPGRADE
            if (changer == 2)
            {
                double priceX25 = checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 25);
                TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(priceX25);
                CanBuy(priceX25);
            }

            //50 UPGRADE
            if (changer == 3)
            {
                double priceX50 = checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 50);
                TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(priceX50);
                CanBuy(priceX50);
            }

            //100 UPGRADE
            if (changer == 4)
            {
                double priceX100 = checkPrice(UPGRADE_Price, UPGRADE_PriceChange, 100);
                TEXT_Price.text = "Cost: " + NumberConverter.FormatNumber(priceX100);
                CanBuy(priceX100);
            }

        }
    }
}
