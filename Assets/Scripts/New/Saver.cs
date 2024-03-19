using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class Saver : MonoBehaviour
{
    public Storage Storage;

    string[,] CU ={ { "CU_1_Level", "CU_1_Price", "CU_1_Bonus" },
                    { "CU_2_Level", "CU_2_Price", "CU_2_Bonus" },
                    { "CU_3_Level", "CU_3_Price", "CU_3_Bonus" },
                    { "CU_4_Level", "CU_4_Price", "CU_4_Bonus" },
                    { "CU_5_Level", "CU_5_Price", "CU_5_Bonus" },
                    { "CU_6_Level", "CU_6_Price", "CU_6_Bonus" },
                    { "CU_7_Level", "CU_7_Price", "CU_7_Bonus" },
                    { "CU_8_Level", "CU_8_Price", "CU_8_Bonus" },
    };

    string[,] IU ={ { "IU_1_Level", "IU_1_Price", "IU_1_Bonus" },
                    { "IU_2_Level", "IU_2_Price", "IU_2_Bonus" },
                    { "IU_3_Level", "IU_3_Price", "IU_3_Bonus" },
                    { "IU_4_Level", "IU_4_Price", "IU_4_Bonus" },
                    { "IU_5_Level", "IU_5_Price", "IU_5_Bonus" },
                    { "IU_6_Level", "IU_6_Price", "IU_6_Bonus" },
                    { "IU_7_Level", "IU_7_Price", "IU_7_Bonus" },
                    { "IU_8_Level", "IU_8_Price", "IU_8_Bonus" },
    };
    public void SaveData()
    {
        for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
        {
            ClickUpgrade temp = Storage.ClickUpgrades[i].GetComponent<ClickUpgrade>();
            PlayerPrefs.SetInt(CU[i, 0], temp.UPGRADE_Level);
            PlayerPrefs.SetString(CU[i, 1], temp.UPGRADE_Price.ToString());
            PlayerPrefs.SetString(CU[i, 2], temp.UPGRADE_Bonus.ToString());
        }
    }


    public void LoadData()
    {
        for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
        {
            ClickUpgrade temp = Storage.ClickUpgrades[i].GetComponent<ClickUpgrade>();
            temp.UPGRADE_Level = PlayerPrefs.GetInt(CU[i, 0], 0);
            temp.UPGRADE_Price = double.Parse(PlayerPrefs.GetString(CU[i, 1], temp.START_Price.ToString()));
            temp.UPGRADE_Bonus = double.Parse(PlayerPrefs.GetString(CU[i, 2], 0.ToString()));
        }
    }



    void Start()
    {
        LoadData();
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
    public void KeyReset()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        //this.gameObject.GetComponent<UpgradeManager>().ShowUpgradesPerLevel();
    }
}
