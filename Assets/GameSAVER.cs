using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameSAVER : MonoBehaviour
{
    private int lvl;
    private float price;
    private float bonus;

    public GameObject[] ClickUpgrades;

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
        PlayerPrefs.SetInt(temp.lvl.ToString(), lvl);
        PlayerPrefs.SetFloat(temp.bonus.ToString(), price);
        PlayerPrefs.SetFloat(temp.price.ToString(), bonus);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        UpgradeInfo temp = ClickUpgrades[0].GetComponent<UpgradeInfo>();
        temp.lvl = PlayerPrefs.GetInt(temp.lvl.ToString(), 1);
        temp.price = PlayerPrefs.GetFloat(temp.bonus.ToString(), 2);
        temp.bonus = PlayerPrefs.GetFloat(temp.price.ToString(), 1);
    }

    void Start()
    {
        LoadData();
    }
}
