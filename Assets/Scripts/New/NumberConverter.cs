using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberConverter : MonoBehaviour
{
    public string FormatNumber(double number)
    {
        if (number >= 1000)
        {
            if (number >= 1000 && number < 1000000)
            {
                return (number / 1000).ToString("F2") + "k";
            }
            else if (number >= 1000000 && number < 1000000000)
            {
                return (number / 1000000).ToString("F2") + "M";
            }
            else if (number >= 1000000000 && number < 1000000000000)
            {
                return (number / 1000000000).ToString("F2") + "B";
            }
            else
            {
                return number.ToString("F2");
            }
        }
        else
        {
            return number.ToString("F0");
        }
    }

    public string FormatNumberFloat(double number)
    {
        if (number >= 1000)
        {
            if (number >= 1000 && number < 1000000)
            {
                return (number / 1000).ToString("F2") + "k";
            }
            else if (number >= 1000000 && number < 1000000000)
            {
                return (number / 1000000).ToString("F2") + "M";
            }
            else if (number >= 1000000000 && number < 1000000000000)
            {
                return (number / 1000000000).ToString("F2") + "B";
            }
            else
            {
                return number.ToString("F2");
            }
        }
        else
        {
            return number.ToString("F2");
        }
    }

	public string FormatNumberfloat1(double number)
	{
		if (number >= 1000)
		{
			if (number >= 1000 && number < 1000000)
			{
				return (number / 1000).ToString("F1") + "k";
			}
			else if (number >= 1000000 && number < 1000000000)
			{
				return (number / 1000000).ToString("F1") + "M";
			}
			else if (number >= 1000000000 && number < 1000000000000)
			{
				return (number / 1000000000).ToString("F1") + "B";
			}
			else
			{
				return number.ToString("F1");
			}
		}
		else
		{
			return number.ToString("F1");
		}
	}
}
