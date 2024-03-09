using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberConverter : MonoBehaviour
{
	public string FormatNumber(float number)
	{
		if (number != 0f)
		{

			if (Mathf.Abs(number) >= 1000 && Mathf.Abs(number) < 1000000)
			{
				return (number / 1000f).ToString("F2") + "k";
			}
			else if (Mathf.Abs(number) >= 1000000 && Mathf.Abs(number) < 1000000000)
			{
				return (number / 1000000f).ToString("F2") + "M";
			}
			else if (Mathf.Abs(number) >= 1000000000 && Mathf.Abs(number) < 1000000000000)
			{
				return (number / 1000000000f).ToString("F2") + "B";
			}
			else
			{
				return number.ToString("F2");
			}
		}
		else
		{
			return number.ToString();
		}
	}
}
