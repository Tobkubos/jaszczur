using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public double    val_TotalCash;
    public double    val_CashPerClick;
    public double    val_CashPerSec;
    public double    val_Diamonds;

    public double    val_MaxMultiplier;
    public double    val_MultiplierCooldown;

    public int       val_ProfileLevel;
    public int       val_ProfileExperienceToNextLvl;

    public GameObject[] ClickUpgrades;
    public GameObject[] IdleUpgrades;
    public GameObject[] MultiplierUpgrades;

    public TextMeshProUGUI TEXT_TotalCash;
    public TextMeshProUGUI TEXT_CashPerClick;
    public TextMeshProUGUI TEXT_CashPerSec;
    public TextMeshProUGUI TEXT_Diamonds;
    public TextMeshProUGUI TEXT_ProfileLevel;
    public TextMeshProUGUI TEXT_ProfileExperienceToNextLvl;
    public NumberConverter NumberConverter;
    private void Update()
    {
        TEXT_TotalCash.text     = NumberConverter.FormatNumber(val_TotalCash);
        TEXT_CashPerClick.text  = NumberConverter.FormatNumber(val_CashPerClick) + " per click";
        TEXT_CashPerSec.text    = NumberConverter.FormatNumber(val_CashPerSec)+ " /s";
        TEXT_Diamonds.text      = NumberConverter.FormatNumber(val_Diamonds);
        //proflie
        //exp
    }
}
