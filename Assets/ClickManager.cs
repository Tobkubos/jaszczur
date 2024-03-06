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
    public GameObject CLICK_UPGRADES;
    public GameObject IDLE_UPGRADES;

    private void Start()
    {
        StartCoroutine(IdleGain());
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
            dynamicMultiplierCooldown += 0.25f;
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

    public void ClickPerSec()
    {
        CashPerSsec += 1f;
    }

    public IEnumerator IdleGain()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Cash += CashPerSsec / 10f;
        }
    }


    public void ShowClickUpgrades()
    {

    }
}
