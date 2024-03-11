using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameSAVER : MonoBehaviour
{

    public GameObject[] ClickUpgrades;

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

    string[] MainSTATS = { "CashPerClick", "CashPerSecond", "IU_1_Bonus" };
    public void KeyReset()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveData();
        }
    }
    void OnApplicationQuit()
    {
        SaveData();
    }

    void SaveData()
    {
        for (int i = 0; i < ClickUpgrades.Length; i++)
        {
            UpgradeInfo temp = ClickUpgrades[i].GetComponent<UpgradeInfo>();
            PlayerPrefs.SetInt(CU[i, 0], temp.lvl);
            PlayerPrefs.SetFloat(CU[i, 1], temp.price);
            PlayerPrefs.SetFloat(CU[i, 2], temp.bonus);

            UnityEngine.Debug.Log(temp.lvl + " " + temp.price + " " + temp.bonus);
        }
    }

    public void LoadData()
    {
        for (int i = 0; i < ClickUpgrades.Length; i++)
        {
            UpgradeInfo temp = ClickUpgrades[i].GetComponent<UpgradeInfo>();
            temp.lvl = PlayerPrefs.GetInt(CU[i, 0], 1);
            temp.price = PlayerPrefs.GetFloat(CU[i, 1], 2);
            temp.bonus = PlayerPrefs.GetFloat(CU[i, 2], 0);
            UnityEngine.Debug.Log(temp.lvl + " " + temp.price + " " + temp.bonus);
        }
    }

    void Start()
    {
        LoadData();
    }
}
