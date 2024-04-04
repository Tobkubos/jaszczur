using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    Storage Storage;
    public bool StartMultiplier     = false;
    public bool ExpPerClick         = false;
    public bool MultiplierPerClick  = false;
    public bool DiamondPercentage   = false;
    public double bonus;
    //
    [Header("Type Of Achievement")]
    //
    public bool LevelAchievement = false;
    public int levelToAchieve = 0;


    public bool collected = false;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Desc;
    public GameObject button;
    public GameObject divider;
    public string achSaveName;

    private void Start()
    {
        Storage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Storage>();
        if(PlayerPrefs.GetInt(achSaveName) == 1)
        {
            Collect();
        }
        else
        {
            Name.color = Color.white;
            Desc.color = Color.white;
            divider.GetComponent<Image>().color = Color.white;
        }
    }

    private void Update()
    {
        if (LevelAchievement)
        {
            if(Storage.val_ProfileLevel >= levelToAchieve && !collected)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
        if(PlayerPrefs.GetInt(achSaveName) == 0)
        {
            Name.color = Color.white;
            Desc.color = Color.white;
            divider.GetComponent<Image>().color = Color.white;
        }
    }
    public void Collect()
    {
        button.GetComponent<Button>().interactable = false;
        collected = true;

        //rodzaj upgrade - dostan nagrode
        if (StartMultiplier)
        {
            Storage.val_ach_StartMultiplier += bonus;
        }
        if (ExpPerClick)
        {
            Storage.val_ach_experiencePerClick += bonus;
        }
        if (MultiplierPerClick)
        {
            Storage.val_ach_MultiplierPerClick += bonus;
        }

        Name.color = Color.yellow;
        Desc.color = Color.yellow;
        divider.GetComponent<Image>().color = Color.yellow;

        //
        PlayerPrefs.SetInt(achSaveName, 1);
        //
    }

}
