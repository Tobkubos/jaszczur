using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Storage Storage;
    public NumberConverter NumberConverter;
    private bool DynMul = false;
    private float normalizedTime;
    public float Cooldown = 10;
    int clicks = 0;
    public TextMeshProUGUI CPSTXT;
    public ParticleSystem GigaParticleCPS;

    private void FixedUpdate()
    {
        if (Storage.val_MultiplierCooldown < Time.time)
        {
            Storage.val_DynamicMultiplier = 1 + Storage.val_ach_StartMultiplier;
            Storage.val_MultiplierCooldown = 0;
            DynMul = false;
        }

        Storage.Slider.maxValue = 1f;
        normalizedTime = Mathf.Clamp01((Storage.val_MultiplierCooldown - Time.time) / 3f);
        Storage.Slider.value = normalizedTime;
        Storage.TEXT_Multiplier.text = "x" + NumberConverter.FormatNumberFloat(Storage.val_DynamicMultiplier);

        CPSTXT.text = "CPS: " + clicks + " /s";

        if(clicks >= 10)
        {
            GigaParticleCPS.Play();
        }
        else
        {
            GigaParticleCPS.Stop();
        }
    }

    private IEnumerator ClickMinus()
    {
        yield return new WaitForSeconds(1);
        clicks--;
    }
    public void FUNCTION_Click()
    {
        Cooldown = Time.time + 5;
        Debug.Log(Cooldown);
        if (DynMul == false)
        {
            Storage.val_MultiplierCooldown = Time.time + 3f;
            DynMul = true;
        }

        if (DynMul == true && Storage.val_MultiplierCooldown > Time.time)
        {
            //
            Storage.val_DynamicMultiplier += 0.01f + Storage.val_MultiplierPerClick;
            if (Storage.val_MultiplierCooldown < Time.time + 3)
            {
                //
                Storage.val_MultiplierCooldown += 0.25f;
            }
            if (Storage.val_DynamicMultiplier > Storage.val_MaxMultiplier)
            {
                Storage.val_DynamicMultiplier = Storage.val_MaxMultiplier;
            }
        }


        //CPS
        clicks++;
        StartCoroutine(ClickMinus());
        

        // DODANIE KASY
        Storage.val_TotalCash += Storage.val_CashPerClick * Storage.val_DynamicMultiplier;
        Storage.val_experience += 1 + Storage.val_ach_experiencePerClick;
		Storage.ParticleClick.Play();
		//

        //SZANSA NA TOILETA!
		int tempDiamond = UnityEngine.Random.Range(0, 100);
        if (tempDiamond <= Storage.val_DiamondsChance)
        {
            Storage.val_Diamonds += 1;
            PlayerPrefs.SetString("TotalDiamonds", Storage.val_Diamonds.ToString());
            Storage.TEXT_Diamonds.text = Storage.val_Diamonds.ToString();
        }

        //ANIMACJA
        Storage.ClickObject.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scale(Storage.ClickObject, new Vector3(1.1f, 1.1f, 1.1f), 0.05f);
        LeanTween.scale(Storage.ClickObject, new Vector3(1f, 1f, 1f), 0.05f).setDelay(0.05f);

        int temp = UnityEngine.Random.Range(0, 2);
        if (temp == 0)
        {
            LeanTween.rotate(Storage.ClickObject, new Vector3(0, 0, 5), 0.05f);
            LeanTween.rotate(Storage.ClickObject, new Vector3(0, 0, 0), 0.05f).setDelay(0.05f);
        }

        if (temp == 1)
        {
            LeanTween.rotate(Storage.ClickObject, new Vector3(0, 0, -5), 0.05f);
            LeanTween.rotate(Storage.ClickObject, new Vector3(0, 0, 0), 0.05f).setDelay(0.05f);
        }

        LeanTween.scale(Storage.Cash_Icon, new Vector3(1.1f, 1.1f, 1.1f), 0.05f);
		LeanTween.scale(Storage.Cash_Icon, new Vector3(1f, 1f, 1f), 0.05f).setDelay(0.05f);
		LeanTween.value(Storage.TEXT_TotalCash.fontSize, Storage.TEXT_TotalCash.fontSize + 20, 0.05f).setOnUpdate((float val) =>
        {
            Storage.TEXT_TotalCash.fontSize = Mathf.RoundToInt(val);
        });

        LeanTween.value(Storage.TEXT_TotalCash.fontSize, Storage.Fsize, 0.05f).setDelay(0.05f).setOnUpdate((float val) => {
            Storage.TEXT_TotalCash.fontSize = Mathf.RoundToInt(val);
        });
    }
}
