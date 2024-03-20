using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public double    val_TotalCash;
    public double    val_CashPerClick;
    public double    val_CashPerSec;
    public double    val_Diamonds;
    public double    val_DiamondsChance;

    public float     val_MaxMultiplier;
    public float     val_MultiplierCooldown;
    public double    val_DynamicMultiplier;

    public int       val_ProfileLevel;
    public int       val_ProfileExperienceToNextLvl;

    public float Fsize;

    public GameObject[] ClickUpgrades;
    public GameObject[] IdleUpgrades;
    public GameObject[] MultiplierUpgrades;
    public GameObject   LIST_ClickUpgraes;
    public GameObject   LIST_IdleUpgraes;
    public GameObject   LIST_MultiplierUpgraes;

    public GameObject   ClickObject;
    public Slider       Slider;

    public TextMeshProUGUI TEXT_TotalCash;
    public TextMeshProUGUI TEXT_CashPerClick;
    public TextMeshProUGUI TEXT_CashPerSec;
    public TextMeshProUGUI TEXT_Diamonds;
    public TextMeshProUGUI TEXT_ProfileLevel;
    public TextMeshProUGUI TEXT_ProfileExperienceToNextLvl;
    public TextMeshProUGUI TEXT_Multiplier;

    public NumberConverter NumberConverter;

    void Start()
    {
        Fsize = TEXT_TotalCash.fontSize;
    }
    void Update()
    {
        TEXT_TotalCash.text     = NumberConverter.FormatNumber(val_TotalCash);
        TEXT_CashPerClick.text  = NumberConverter.FormatNumber(val_CashPerClick) + " per click";
        TEXT_CashPerSec.text    = NumberConverter.FormatNumber(val_CashPerSec)+ " /s";
        TEXT_Diamonds.text      = NumberConverter.FormatNumber(val_Diamonds);
        //proflie
        //exp
    }
}
