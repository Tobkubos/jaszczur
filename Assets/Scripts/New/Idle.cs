using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
	public Storage Storage;
	public IEnumerator IdleGain()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.05f);
			Storage.val_TotalCash += Storage.val_CashPerSec / 20f;
		}
	}

	private void Start()
	{
		StartCoroutine(IdleGain());
	}
}
