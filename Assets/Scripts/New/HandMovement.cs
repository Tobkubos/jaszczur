using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
	public Click click;
	private bool isActive;
	public GameObject hand;
    void Start()
    {
        StartCoroutine(Animation());
		hand.gameObject.SetActive(false);
	}

	private void Update()
	{
		Debug.Log(click.Cooldown);
		if (Time.time > click.Cooldown && isActive==false)
		{
			isActive= true;
			hand.gameObject.SetActive(true);
		}
		if (Time.time < click.Cooldown && isActive == true)
		{
			isActive = false;
			hand.gameObject.SetActive(false);
		}

	}
	IEnumerator Animation()
    {
		float speed = 0.5f;
		float move = 5;
		while (hand.gameObject.activeSelf)
        {
            LeanTween.moveX(hand.gameObject, hand.gameObject.transform.position.x + move, speed).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			LeanTween.moveY(hand.gameObject, hand.gameObject.transform.position.y - move, speed).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			yield return new WaitForSeconds(1);
			LeanTween.moveX(hand.gameObject, hand.gameObject.transform.position.x - move, speed).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			LeanTween.moveY(hand.gameObject, hand.gameObject.transform.position.y + move, speed).setLoopPingPong().setEase(LeanTweenType.easeInOutSine);
			yield return new WaitForSeconds(1);
		}
    }
}
