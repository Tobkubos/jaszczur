using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
	public Storage Storage;
	public NumberConverter NumberConverter;

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
		Storage.OfflineIncomeBox.SetActive(true);
	}

	public void Collect()
	{
		Storage.val_TotalCash += Storage.SECONDS * Storage.val_CashPerSec;
		Storage.OfflineIncomeBox.SetActive(false);
	}

	public void Collect2X()
	{
		//odpal reklame
		Storage.TEXT_OfflineIncome.text = NumberConverter.FormatNumber(Storage.SECONDS * Storage.val_CashPerSec * 2f);
		Storage.val_TotalCash += Storage.SECONDS * Storage.val_CashPerSec * 2;
		Storage.OfflineIncomeBox.SetActive(false);
	}
}
