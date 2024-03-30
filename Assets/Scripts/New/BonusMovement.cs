using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    public Storage Storage;
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        float tick = 0.1f;
        float angle = 15f;
        while (true)
        {
            yield return new WaitForSeconds(3);
            for (int i =0; i < 5; i++) {
                yield return new WaitForSeconds(tick*4);
                LeanTween.rotate(Storage.Bonus_Popup, new Vector3(0, 0, angle), tick);
                LeanTween.rotate(Storage.Bonus_Popup, new Vector3(0, 0, 0), tick).setDelay(tick);
                LeanTween.rotate(Storage.Bonus_Popup, new Vector3(0, 0, -angle), tick).setDelay(tick * 2);
                LeanTween.rotate(Storage.Bonus_Popup, new Vector3(0, 0, 0), tick).setDelay(tick * 3);
            } 
        }
    }
}
