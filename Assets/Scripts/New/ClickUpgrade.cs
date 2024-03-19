using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickUpgrade : MonoBehaviour
{
    [Header("TEXT MESH PRO")]
    public string           STRING_NameOfUpgrade;
    public TextMeshProUGUI  TEXT_NameOfUpgrade;
    public TextMeshProUGUI  TEXT_BonusChange;
    public TextMeshProUGUI  TEXT_Bonus;
    public TextMeshProUGUI  TEXT_Level;

    [Header("START VALUES")]
    public int          START_Level;
    public double       START_Bonus;
    public double       START_Price;
    public double       START_BonusChange;

    [Header("VALUES")]
    public int      UPGRADE_Level;
    public double   UPGRADE_Bonus;
    public double   UPGRADE_Price;
    public double   UPGRADE_BonusChange;

    public GameObject[] stars;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
