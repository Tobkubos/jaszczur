using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Prestige : MonoBehaviour
{
    public Storage Storage;
    void Update()
    {
        Storage.TEXT_Prestige.text = Storage.val_PrestigeBonus.ToString();
    }


    public void Calculate()
    {
        double prestigeCount = 0;
        for (int i = 0; i < Storage.ClickUpgrades.Length; i++)
        {
            Upgrade temp = Storage.ClickUpgrades[i].GetComponent<Upgrade>();
            prestigeCount += temp.UPGRADE_Level * (i+1);
        }

        for (int i = 0; i < Storage.IdleUpgrades.Length; i++)
        {
            Upgrade temp = Storage.IdleUpgrades[i].GetComponent<Upgrade>();
            prestigeCount += temp.UPGRADE_Level * (i + 1);
        }

        for (int i = 0; i < Storage.MultiplierUpgrades.Length; i++)
        {
            Upgrade temp = Storage.MultiplierUpgrades[i].GetComponent<Upgrade>();
            prestigeCount += temp.UPGRADE_Level * (i + 1);
        }

        Storage.val_PrestigeBonus = prestigeCount;
        PlayerPrefs.SetString("PrestigeBonus", Storage.val_PrestigeBonus.ToString());
    }
}
