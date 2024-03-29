using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Animation());
		this.gameObject.SetActive(false);
	}
	IEnumerator Animation()
    {
		while (this.gameObject.activeSelf)
        {
            LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x + 50f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y - 50f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			yield return new WaitForSeconds(1);
			LeanTween.moveX(this.gameObject, this.gameObject.transform.position.x - 50f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			LeanTween.moveY(this.gameObject, this.gameObject.transform.position.y + 50f, 1).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			yield return new WaitForSeconds(1);
		}

    }
}
