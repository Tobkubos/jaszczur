using System.Collections;
using UnityEngine;

public class Idle : MonoBehaviour
{
	public Storage Storage;
	public NumberConverter NumberConverter;
	public int FirstStart = 1;

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
		FirstStart = PlayerPrefs.GetInt("FirstStart", 1);
		if (FirstStart == 0)
		{
			Storage.OfflineIncomeBox.SetActive(true);
		}

		if (FirstStart == 1)
		{
			Storage.OfflineIncomeBox.SetActive(false);
			FirstStart= 0;
			PlayerPrefs.SetInt("FirstStart", FirstStart);
		}

		StartCoroutine(IdleGain());

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
