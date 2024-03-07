using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeInfo : MonoBehaviour
{
    public float price=10;
    public float bonus=1;
    private int[] tab = new int[5];
    private int i = 0;
    private int lvl = 0;

    public GameObject buyButton;
    public TextMeshProUGUI buyCount;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI bonusText;

    private ClickManager Manager;
    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<ClickManager>();
        tab[0] = 1;
        tab[1] = 10;
        tab[2] = 25;
        tab[3] = 50;
        tab[4] = 100;
        priceText.text = price.ToString();
        levelText.text = lvl.ToString();
        bonusText.text = "+ " + bonus.ToString();
    }
    private void Update()
    {
        if (Manager.Cash < price)
        {
            buyButton.GetComponent<Image>().color = Color.red;
        }
        if(Manager.Cash >= price)
        {
            buyButton.GetComponent<Image>().color = Color.green;
        }
    }
    public void changeBuyCount()
    {
        i++;
        buyCount.text = "x " + tab[i].ToString();
        if(i == 4)
        {
            i = -1;
        }
    }


    public void buy1time()
    {
        bonus += 1f;
        price *= 1.5f;
        lvl += 1;
        priceText.text = price.ToString();
        levelText.text = lvl.ToString();
        bonusText.text = "+ " + bonus.ToString();
    }
    private void buy10times()
    {
        for(int i =0; i < 10; i++)
        {

        }
    }
}
