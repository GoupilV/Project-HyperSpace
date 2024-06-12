using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text textTimer;
	private float temps;
	private bool estLance;

	void Start()
	{
		temps = 0f;
		estLance = true;
		MajTempsTimer();
	}

	// Update is called once per frame
	void Update()
	{
		if (estLance)
		{
			temps += Time.deltaTime;
			MajTempsTimer();
		}
	}
	public void DebutTimer()
	{
		estLance = true;
	}
	public void ArretTimer()
	{
		estLance = false;
	}
	public void ResetTimer()
	{
		temps = 0f;
		MajTempsTimer();
	}
	public float TempsPris()
	{
		return temps;
	}
	private void MajTempsTimer()
	{
		int minutes = Mathf.FloorToInt(temps / 60f);
		int secondes = Mathf.FloorToInt(temps % 60f);
		int milliS = Mathf.FloorToInt((temps * 100f) % 100f);
		textTimer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, secondes, milliS);
	}
}
