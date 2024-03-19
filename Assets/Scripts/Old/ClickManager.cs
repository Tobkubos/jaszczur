using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour
{
	private NumberConverter NumberConverter;

	public GameObject MAINCLICKOBJECT;
    public GameObject UPGRADES_MENU;

    [Header("UPGRADES LIST")]
    public GameObject CLICK_UPGRADES_LIST;
    public GameObject IDLE_UPGRADES_LIST;
    public GameObject MULTIPLIER_UPGRADE_LIST;
    public GameObject OTHER_UPGRADES_LIST;
    public RectTransform Canva;

    [Header("TEXTS")]
    public TextMeshProUGUI TotalCash;
    public TextMeshProUGUI CashPS;
    public TextMeshProUGUI CashPerClick;
    public TextMeshProUGUI DynamicM;
    public TextMeshProUGUI DiamondsText;
    public Slider DynamicMSlider;

    public ParticleSystem ClickParticleSystem;

    public float click = 1;
    public float Cash = 0;
    public float CashPerSsec = 0;

    public int diamonds = 0;
    public int diamondsChance = 1;

    public float dynamicMultiplier = 1;
    public float dynamicMultiplierCooldown = 0;
    public bool DynMul = false;
    float normalizedTime;

    public bool CLICKED = false;
    public bool CanCLick = true;

    private float Fsize; 
    private void Start()
    {
        Fsize =  TotalCash.fontSize;
        this.gameObject.GetComponent<UpgradeManager>().FUNCTION_TotalCashPerClick();
        StartCoroutine(IdleGain());
        NumberConverter = GetComponent<NumberConverter>();
        UPGRADES_MENU.transform.localPosition = new Vector3(0,-Canva.rect.height+200,0);
    }
    private void FixedUpdate()
    {
        TotalCash.text = NumberConverter.FormatNumber(Cash);
        CashPS.text = "+" + CashPerSsec.ToString("F0") + "/s";
        CashPerClick.text = "+" + click.ToString("F0") + " per click";

        DynamicM.text = "x" + NumberConverter.FormatNumber(dynamicMultiplier);

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
            dynamicMultiplier += 0.01f;
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
        int tempDiamond = Random.Range(0, 100);
        if(tempDiamond <= diamondsChance)
        {
            diamonds += 1;
            DiamondsText.text = diamonds.ToString();
        }
        
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

        LeanTween.value(TotalCash.fontSize, TotalCash.fontSize + 20, 0.05f).setOnUpdate((float val) =>
        {
            TotalCash.fontSize = Mathf.RoundToInt(val);
        });
       
        LeanTween.value(TotalCash.fontSize, Fsize, 0.05f).setDelay(0.05f).setOnUpdate((float val) => {
            TotalCash.fontSize = Mathf.RoundToInt(val);
        });

    }

    public IEnumerator IdleGain()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            Cash += CashPerSsec / 20f;
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
                LeanTween.moveLocalY(UPGRADES_MENU, -Canva.rect.height/3 - 200f, 0.5f).setEase(LeanTweenType.easeInOutSine);
            }
            else if (CLICKED == true)
            {
                CLICKED = false;
                LeanTween.moveLocalY(UPGRADES_MENU, -Canva.rect.height + 200, 0.5f).setEase(LeanTweenType.easeInOutSine);
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
        MULTIPLIER_UPGRADE_LIST.SetActive(false);
        OTHER_UPGRADES_LIST.SetActive(false);
    }
    public void ShowIdleUpgrades()
    {
        IDLE_UPGRADES_LIST.SetActive(true);
        CLICK_UPGRADES_LIST.SetActive(false);
        MULTIPLIER_UPGRADE_LIST.SetActive(false);
        OTHER_UPGRADES_LIST.SetActive(false);
    }
    public void ShowCMultiplierUpgrades()
    {
        CLICK_UPGRADES_LIST.SetActive(false);
        IDLE_UPGRADES_LIST.SetActive(false);
        MULTIPLIER_UPGRADE_LIST.SetActive(true);
        OTHER_UPGRADES_LIST.SetActive(false);
    }
    public void ShowOtherUpgrades()
    {
        CLICK_UPGRADES_LIST.SetActive(false);
        IDLE_UPGRADES_LIST.SetActive(false);
        MULTIPLIER_UPGRADE_LIST.SetActive(false);
        OTHER_UPGRADES_LIST.SetActive(true);
    }
}
