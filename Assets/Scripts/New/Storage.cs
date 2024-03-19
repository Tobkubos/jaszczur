using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public double   val_TotalCash;
    public double   val_CashPerClick;
    public double   val_CashPerSec;
    public double    val_Diamonds;

    public double   val_MaxMultiplier;
    public double   val_MultiplierCooldown;

    public int      val_ProfileLevel;
    public int      val_ProfileExperienceToNextLvl;

    public GameObject[] ClickUpgrades;
    public GameObject[] IdleUpgrades;
    public GameObject[] MultiplierUpgrades;
    private void Start()
    {
        //Saver - Load data
    }
}
