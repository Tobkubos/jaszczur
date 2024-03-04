using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float click = 1;
    public float Cash = 0;
    public float CashPerSsec = 0;

    public TextMeshProUGUI TotalCash;

    private void Start()
    {
        StartCoroutine(IdleGain());
    }
    private void FixedUpdate()
    {
        string temp = Cash.ToString("F2");
        TotalCash.text = temp;
    }

    public void Click()
    {
        Cash += click;
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
}
