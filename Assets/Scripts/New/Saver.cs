using UnityEngine;
using System;
using System.Collections;

public class Saver : MonoBehaviour
{
    public Storage Storage;
    public NumberConverter NumberConverter;
	public DataInternetSaver DataInternetSaver;

    string[,] CU ={ { "CU_1_Level", "CU_1_Price", "CU_1_Bonus" },
                    { "CU_2_Level", "CU_2_Price", "CU_2_Bonus" },
                    { "CU_3_Level", "CU_3_Price", "CU_3_Bonus" },
                    { "CU_4_Level", "CU_4_Price", "CU_4_Bonus" },
                    { "CU_5_Level", "CU_5_Price", "CU_5_Bonus" },
                    { "CU_6_Level", "CU_6_Price", "CU_6_Bonus" },
                    { "CU_7_Level", "CU_7_Price", "CU_7_Bonus" },
                    { "CU_8_Level", "CU_8_Price", "CU_8_Bonus" },
					{ "CU_9_Level", "CU_9_Price", "CU_9_Bonus" },
					{ "CU_10_Level", "CU_10_Price", "C_10_Bonus" },
	};

    string[,] IU ={ { "IU_1_Level", "IU_1_Price", "IU_1_Bonus" },
                    { "IU_2_Level", "IU_2_Price", "IU_2_Bonus" },
                    { "IU_3_Level", "IU_3_Price", "IU_3_Bonus" },
                    { "IU_4_Level", "IU_4_Price", "IU_4_Bonus" },
                    { "IU_5_Level", "IU_5_Price", "IU_5_Bonus" },
                    { "IU_6_Level", "IU_6_Price", "IU_6_Bonus" },
                    { "IU_7_Level", "IU_7_Price", "IU_7_Bonus" },
                    { "IU_8_Level", "IU_8_Price", "IU_8_Bonus" },
					{ "IU_9_Level", "IU_9_Price", "IU_9_Bonus" },
					{ "IU_10_Level", "IU_10_Price", "IU_10_Bonus" },
	};

	string[,] MU ={ { "MU_1_Level", "MU_1_Price", "MU_1_Bonus" },
					{ "MU_2_Level", "MU_2_Price", "MU_2_Bonus" },
					{ "MU_3_Level", "MU_3_Price", "MU_3_Bonus" },
					{ "MU_4_Level", "MU_4_Price", "MU_4_Bonus" },
					{ "MU_5_Level", "MU_5_Price", "MU_5_Bonus" },
					{ "MU_6_Level", "MU_6_Price", "MU_6_Bonus" },
					{ "MU_7_Level", "MU_7_Price", "MU_7_Bonus" },
					{ "MU_8_Level", "MU_8_Price", "MU_8_Bonus" },
					{ "MU_9_Level", "MU_9_Price", "MU_9_Bonus" },
					{ "MU_10_Level", "MU_10_Price", "MU_10_Bonus" },
	};

	string[,] PU ={ { "PU_1_Level", "PU_1_Price", "PU_1_Bonus" },
					{ "PU_2_Level", "PU_2_Price", "PU_2_Bonus" },
					{ "PU_3_Level", "PU_3_Price", "PU_3_Bonus" },
					{ "PU_4_Level", "PU_4_Price", "PU_4_Bonus" },
					{ "PU_5_Level", "PU_5_Price", "PU_5_Bonus" },
					{ "PU_6_Level", "PU_6_Price", "PU_6_Bonus" },
					{ "PU_7_Level", "PU_7_Price", "PU_7_Bonus" },
					{ "PU_8_Level", "PU_8_Price", "PU_8_Bonus" },
					{ "PU_9_Level", "PU_9_Price", "PU_9_Bonus" },
					{ "PU_10_Level", "PU_10_Price", "pU_10_Bonus" },
	};

	public void SaveData()
    {
		for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
        {
            Upgrade temp = Storage.ClickUpgrades[i].GetComponent<Upgrade>();
            PlayerPrefs.SetInt(CU[i, 0], temp.UPGRADE_Level);
            PlayerPrefs.SetString(CU[i, 1], temp.UPGRADE_Price.ToString());
            PlayerPrefs.SetString(CU[i, 2], temp.UPGRADE_Bonus.ToString());
        }
        for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
        {
            Upgrade temp = Storage.IdleUpgrades[i].GetComponent<Upgrade>();
            PlayerPrefs.SetInt(IU[i, 0], temp.UPGRADE_Level);
            PlayerPrefs.SetString(IU[i, 1], temp.UPGRADE_Price.ToString());
            PlayerPrefs.SetString(IU[i, 2], temp.UPGRADE_Bonus.ToString());
        }
        PlayerPrefs.SetString("TotalCash", Storage.val_TotalCash.ToString());
		PlayerPrefs.SetString("TotalDiamonds", Storage.val_Diamonds.ToString());
		PlayerPrefs.SetString("Level", Storage.val_ProfileLevel.ToString());
		PlayerPrefs.SetString("Experience", Storage.val_experience.ToString());
		PlayerPrefs.SetString("ExperienceToNextLevel", Storage.val_ProfileExperienceToNextLvl.ToString());
		//PlayerPrefs.SetString("Time_OUT", DateTime.Now.ToString()); 
    }
	public void LoadData()
    {
        Storage.val_TotalCash =                  double.Parse(PlayerPrefs.GetString("TotalCash", 0.ToString()));
        Storage.val_Diamonds =                   double.Parse(PlayerPrefs.GetString("TotalDiamonds", 0.ToString()));
		Storage.val_ProfileLevel =               int.Parse(PlayerPrefs.GetString("Level", 0.ToString()));
        Storage.val_experience =                 double.Parse(PlayerPrefs.GetString("Experience", 0.ToString()));
		Storage.val_ProfileExperienceToNextLvl = double.Parse(PlayerPrefs.GetString("ExperienceToNextLevel", 10.ToString()));
		Storage.val_CashPerClick = 1;
		Storage.val_CashPerSec = 0;
		Storage.val_MaxMultiplier = 2;
		for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
        {
            Upgrade temp = Storage.ClickUpgrades[i].GetComponent<Upgrade>();
            temp.UPGRADE_Level = PlayerPrefs.GetInt(CU[i, 0], 0);
            temp.UPGRADE_Price = double.Parse(PlayerPrefs.GetString(CU[i, 1], temp.START_Price.ToString()));
            temp.UPGRADE_Bonus = double.Parse(PlayerPrefs.GetString(CU[i, 2], 0.ToString()));
            Storage.val_CashPerClick += Storage.ClickUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
        }

		for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
		{
			Upgrade temp = Storage.IdleUpgrades[i].GetComponent<Upgrade>();
			temp.UPGRADE_Level = PlayerPrefs.GetInt(IU[i, 0], 0);
			temp.UPGRADE_Price = double.Parse(PlayerPrefs.GetString(IU[i, 1], temp.START_Price.ToString()));
			temp.UPGRADE_Bonus = double.Parse(PlayerPrefs.GetString(IU[i, 2], 0.ToString()));
			Storage.val_CashPerSec += Storage.IdleUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
		}

		for (int i = 0; i < Storage.MultiplierUpgrades.Length; i++)
		{
			Upgrade temp = Storage.MultiplierUpgrades[i].GetComponent<Upgrade>();
			temp.UPGRADE_Level = PlayerPrefs.GetInt(MU[i, 0], 0);
			temp.UPGRADE_Price = double.Parse(PlayerPrefs.GetString(MU[i, 1], temp.START_Price.ToString()));
			temp.UPGRADE_Bonus = double.Parse(PlayerPrefs.GetString(MU[i, 2], 0.ToString()));
			Storage.val_MaxMultiplier += Storage.MultiplierUpgrades[i].GetComponent<Upgrade>().UPGRADE_Bonus;
		}

    }

	public void CalcOfflineIncome()
	{
		//OFFLINE INCOME
		DateTime TIME_OUT;
		if (DateTime.TryParse(PlayerPrefs.GetString("Time_OUT", 0.ToString()), out TIME_OUT))
		{
			DateTime TIME_IN;
			if (DateTime.TryParse(PlayerPrefs.GetString("Time_IN", 0.ToString()), out TIME_IN))
			{
				TimeSpan TIME_BETWEEN = TIME_IN - TIME_OUT;
				Storage.SECONDS = TIME_BETWEEN.TotalSeconds;
				Storage.TEXT_OfflineIncome.text = NumberConverter.FormatNumber(Storage.SECONDS * Storage.val_CashPerSec);
				if (TIME_BETWEEN.Days == 0)
				{
					Storage.TEXT_OfflineTime.text = $"{TIME_BETWEEN.Hours} hours\n {TIME_BETWEEN.Minutes} minutes\n {TIME_BETWEEN.Seconds} seconds";
					if (TIME_BETWEEN.Hours == 0)
					{
						Storage.TEXT_OfflineTime.text = $"{TIME_BETWEEN.Minutes} minutes\n {TIME_BETWEEN.Seconds} seconds";
						if (TIME_BETWEEN.Minutes == 0)
						{
							Storage.TEXT_OfflineTime.text = $"{TIME_BETWEEN.Seconds} seconds";
						}
					}
				}
				else
				{
					Storage.TEXT_OfflineTime.text = $"{TIME_BETWEEN.Days}days\n {TIME_BETWEEN.Hours} hours\n {TIME_BETWEEN.Minutes} minutes\n {TIME_BETWEEN.Seconds} seconds";
				}
			}
		}
	}


	void Awake()
    {
		StartCoroutine(DataInternetSaver.FetchDateTime(2));
        LoadData();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
        if (!pause)
        {
            SaveData();
			Debug.Log("ODPAUZOWANE");
            Storage.OfflineIncomeBox.SetActive(true);
        }
    }

    private void OnApplicationFocus(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
        if (!pause)
        {
            SaveData();
            Debug.Log("ODPAUZOWANE");
            Storage.OfflineIncomeBox.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void FactoryReset()
    {
        PlayerPrefs.DeleteAll();
        LoadData();

        Storage.val_ach_experiencePerClick = 0;
        Storage.val_MultiplierPerClick = 0;
        Storage.val_ach_StartMultiplier = 0;

		for (int i = 0; i<Storage.Achievements.Length; i++)
        {
            Storage.Achievements[i].GetComponent<Achievement>().collected = false;
        }

		for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
		{
			Storage.ClickUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}

		for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
		{
			Storage.IdleUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}

		for (int i = 0; i < Storage.MultiplierUpgrades.Length; i++)
		{
			Storage.MultiplierUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}


		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.ClickUpgrades);
		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.IdleUpgrades);
		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.MultiplierUpgrades);
	}

    public void KeyReset()
    {
        
        /*
		PlayerPrefs.SetString("TotalDiamonds", Storage.val_Diamonds.ToString());
		PlayerPrefs.SetString("Level", Storage.val_ProfileLevel.ToString());
		PlayerPrefs.SetString("Experience", Storage.val_experience.ToString());
		PlayerPrefs.SetString("ExperienceToNextLevel", Storage.val_ProfileExperienceToNextLvl.ToString());

		double temp =  double.Parse(PlayerPrefs.GetString("TotalDiamonds", 0.ToString()));
		int temp1 = int.Parse(PlayerPrefs.GetString("Level", 0.ToString()));
		double temp2 = double.Parse(PlayerPrefs.GetString("Experience", 0.ToString()));
		double temp3 = double.Parse(PlayerPrefs.GetString("ExperienceToNextLevel", 10.ToString()));
        */

        //PlayerPrefs.DeleteAll();
        for(int i =0; i < CU.Length/3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                PlayerPrefs.DeleteKey(CU[i,j]);
            }
        }

		for (int i = 0; i < IU.Length/3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				PlayerPrefs.DeleteKey(IU[i, j]);
			}
		}

		for (int i = 0; i < MU.Length / 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				PlayerPrefs.DeleteKey(IU[i, j]);
			}
		}

		PlayerPrefs.DeleteKey("TotalCash");

		LoadData();
		Storage.val_Diamonds += 100;
        SaveData();
		/*
        Storage.val_Diamonds = temp;
        Storage.val_ProfileLevel = temp1;
		Storage.val_experience = temp2;
		Storage.val_ProfileExperienceToNextLvl = temp3;
        */
		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.ClickUpgrades);
		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.IdleUpgrades);
		this.gameObject.GetComponent<UpgradeMenu>().EnableUpgrade(Storage.MultiplierUpgrades);

		for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
		{
            Storage.ClickUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}

		for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
		{
			Storage.IdleUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}

		for (int i = 0; i < Storage.MultiplierUpgrades.Length; i++)
		{
			Storage.MultiplierUpgrades[i].GetComponent<Upgrade>().CheckStars();
		}
	}
}
