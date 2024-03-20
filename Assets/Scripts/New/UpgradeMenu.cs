using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public Storage Storage;
    private void Start()
    {
        EnableUpgrade(Storage.ClickUpgrades);
        //EnableUpgrade(Storage.IdleUpgrades);
        //EnableUpgrade(Storage.MultiplierUpgrades);
    }

    private void Update()
    {
        CheckForUpgrade(Storage.ClickUpgrades);
        //CheckForUpgrade(Storage.IdleUpgrades);
        //CheckForUpgrade(Storage.MultiplierUpgrades);
    }

    private void CheckForUpgrade(GameObject[] tab)
    {
        for (int i = 0; i < tab.Length - 1; i++)
        {
            if (tab[i].GetComponent<Upgrade>().UPGRADE_Level > 10)
            {
                tab[i + 1].SetActive(true);
            }
        }
    }
    public void EnableUpgrade(GameObject[] tab)
    {
        for(int i=0; i<tab.Length; i++)
        {
            tab[i].SetActive(false);
        }
        tab[0].SetActive(true);
    }
}
