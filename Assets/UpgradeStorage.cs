using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeStorage : MonoBehaviour
{
	ClickManager Manager;
    public float[] ClickUpradeStorage = new float[10];
	public float[] IdleUpgradeStorage = new float[10];

	private void Start()
	{
		Manager = GetComponent<ClickManager>();
	}
	private void Update()
	{
		float sum = 1;
		for(int i = 0; i<ClickUpradeStorage.Length; i++)
		{
			sum += ClickUpradeStorage[i];
		}
		Manager.click = sum;
	}
}
