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

    string[,] CU ={ { "CU_1_Level", "CU_1_Price", "CU_1_Bonus" }
    };  // Indeks 0
    public void KeyReset()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        UnityEngine.Debug.Log("USUWAM");
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
        UpgradeInfo temp = ClickUpgrades[0].GetComponent<UpgradeInfo>();
        PlayerPrefs.SetInt(CU[0,0], temp.lvl);
        PlayerPrefs.SetFloat(CU[0,1], temp.price);
        PlayerPrefs.SetFloat(CU[0,2], temp.bonus);

        UnityEngine.Debug.Log(temp.lvl + " " + temp.price + " " + temp.bonus);
    }

    public void LoadData()
    {
        UpgradeInfo temp = ClickUpgrades[0].GetComponent<UpgradeInfo>();
        temp.lvl = PlayerPrefs.GetInt(CU[0,0], 1);
        temp.price = PlayerPrefs.GetFloat(CU[0,1], 2);
        temp.bonus = PlayerPrefs.GetFloat(CU[0,2], 1);
        UnityEngine.Debug.Log(temp.lvl +" "+ temp.price +" "+ temp.bonus);
    }

    void Start()
    {
        LoadData();
    }
}
