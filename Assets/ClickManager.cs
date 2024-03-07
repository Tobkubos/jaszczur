using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
    public float click = 1;
    public float Cash = 0;
    public float CashPerSsec = 0;
    public float dynamicMultiplier = 1;
    public float dynamicMultiplierCooldown = 0;

    public TextMeshProUGUI TotalCash;
    public TextMeshProUGUI CashPS;
    public TextMeshProUGUI CashPerClick;

    public TextMeshProUGUI DynamicM;
    public Slider DynamicMSlider;
    public bool DynMul = false;
    float normalizedTime;

    public GameObject MAINCLICKOBJECT;
    public GameObject UPGRADES_MENU;

    public GameObject CLICK_UPGRADES_LIST;
    public GameObject IDLE_UPGRADES_LIST;

    public bool CLICKED = false;
    public bool CanCLick = true;

    Vector3 startPos;
    float endPos;
    public RectTransform Canva;

    private void Start()
    {
        StartCoroutine(IdleGain());
        UPGRADES_MENU.transform.localPosition = new Vector3(0,-Canva.rect.height+200,0);
    }
    private void FixedUpdate()
    {
        string temp = Cash.ToString("F2");
        TotalCash.text = temp;
        CashPS.text = "+" + CashPerSsec.ToString() + "/s";
        CashPerClick.text = "+" + click.ToString() + " per click";

        DynamicM.text = "x" + dynamicMultiplier.ToString();

        if(dynamicMultiplierCooldown < Time.time)
        {
            dynamicMultiplier = 1;
            DynMul = false;
        }

        DynamicMSlider.maxValue = 1f;
        normalizedTime = Mathf.Clamp01((dynamicMultiplierCooldown - Time.time) / 3f);
        DynamicMSlider.value = normalizedTime;

        Debug.Log(DynMul);
    }

    public void Click()
    {
        if (DynMul == false)
        {
            dynamicMultiplierCooldown = Time.time + 3f;
            DynMul = true;
        }

        if (DynMul == true && dynamicMultiplierCooldown > Time.time)
        {
            dynamicMultiplier += 0.1f;
            if(dynamicMultiplierCooldown < Time.time + 3) 
            {
                dynamicMultiplierCooldown += 0.25f;
            }
            if (dynamicMultiplier > 2f) 
            {
                dynamicMultiplier = 2f;
            }
        }

        Cash += click * dynamicMultiplier;
        MAINCLICKOBJECT.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scale(MAINCLICKOBJECT, new Vector3(1.1f, 1.1f, 1.1f), 0.05f);
        LeanTween.scale(MAINCLICKOBJECT, new Vector3(1f, 1f, 1f), 0.05f).setDelay(0.05f);

        int temp = Random.Range(0, 2);
        if(temp == 0)
        {
            LeanTween.rotate(MAINCLICKOBJECT, new Vector3(0, 0, 5), 0.05f);
            LeanTween.rotate(MAINCLICKOBJECT, new Vector3(0, 0, 0), 0.05f).setDelay(0.05f);
        }

        if(temp == 1)
        {
            LeanTween.rotate(MAINCLICKOBJECT, new Vector3(0, 0, -5), 0.05f);
            LeanTween.rotate(MAINCLICKOBJECT, new Vector3(0, 0, 0), 0.05f).setDelay(0.05f);
        }
        LeanTween.value(TotalCash.fontSize, TotalCash.fontSize+20, 0.05f).setOnUpdate((float val) => {
            TotalCash.fontSize = Mathf.RoundToInt(val);
        });
        LeanTween.value(TotalCash.fontSize, TotalCash.fontSize, 0.05f).setDelay(0.05f).setOnUpdate((float val) => {
            TotalCash.fontSize = Mathf.RoundToInt(val);
        });

    }

    public IEnumerator IdleGain()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Cash += CashPerSsec / 10f;
        }
    }


    public void ShowUpgrades()
    {
        if (CanCLick == true)
        {
            CanCLick = false;

            if (CLICKED == false)
            {
                CLICKED = true;
                StartCoroutine(Cooldown());
                LeanTween.moveLocalY(UPGRADES_MENU, -Canva.rect.height/3 - 200f, 0.5f);
            }
            else if (CLICKED == true)
            {
                CLICKED = false;
                LeanTween.moveLocalY(UPGRADES_MENU, -Canva.rect.height + 200, 0.5f);
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.5f);
        CanCLick = true;
    }

    public void ShowClickUpgrades()
    {
        CLICK_UPGRADES_LIST.SetActive(true);
        IDLE_UPGRADES_LIST.SetActive(false);
    }
    public void ShowIdleUpgrades()
    {
        IDLE_UPGRADES_LIST.SetActive(true);
        CLICK_UPGRADES_LIST.SetActive(false);
    }
}
